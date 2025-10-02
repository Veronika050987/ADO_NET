using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Set
{
	internal class Cache
	{
		private string connectionString;
		private DataSet cachedData;
		private Dictionary<string, string> selectCommands; // TableName -> SelectCommand

		public Cache(string connectionStringName)
		{
			connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
			cachedData = new DataSet();
			selectCommands = new Dictionary<string, string>();
		}
		public void AddTable(string tableName, string selectCommand, string[] primaryKeyColumns)
		{
			if (cachedData.Tables.Contains(tableName))
			{
				throw new ArgumentException($"Table '{tableName}' already exists in the cache.");
			}

			DataTable newTable = new DataTable(tableName);
			cachedData.Tables.Add(newTable);
			selectCommands.Add(tableName, selectCommand);

			// Load data into the table to get column schema
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommand, connection))
				{
					try
					{
						connection.Open();
						adapter.FillSchema(newTable, SchemaType.Source); // Just get schema, don't populate data
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Error filling schema for table '{tableName}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					finally
					{
						connection.Close();
					}
				}
			}

			// Set Primary Key
			DataColumn[] primaryKeys = new DataColumn[primaryKeyColumns.Length];
			for (int i = 0; i < primaryKeyColumns.Length; i++)
			{
				string columnName = primaryKeyColumns[i]; // Store column name in a variable for clarity
				DataColumn column = newTable.Columns[columnName];  // Use variable for clarity

				if (column == null)
				{
					throw new ArgumentException($"PrimaryKey column '{columnName}' not found in table '{tableName}'.", nameof(primaryKeyColumns));
				}

				primaryKeys[i] = column;
			}
			newTable.PrimaryKey = primaryKeys;
		}
		public void LoadData()
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				foreach (var kvp in selectCommands)
				{
					string tableName = kvp.Key;
					string selectCommand = kvp.Value;

					using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommand, connection))
					{
						adapter.Fill(cachedData.Tables[tableName]);
					}
				}
			}
		}
		public DataTable GetTable(string tableName)
		{
			if (!cachedData.Tables.Contains(tableName))
			{
				throw new ArgumentException($"Table '{tableName}' not found in the cache.");
			}

			return cachedData.Tables[tableName];
		}
		public void UpdateTable(string tableName, string updateCommand, string deleteCommand, string insertCommand)
		{
			if (!cachedData.Tables.Contains(tableName))
			{
				throw new ArgumentException($"Table '{tableName}' not found in the cache.");
			}

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommands[tableName], connection)) // Use original select command for adapter

				{
					// Set Update/Delete/Insert commands
					SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

					adapter.UpdateCommand = new SqlCommand(updateCommand, connection);
					adapter.DeleteCommand = new SqlCommand(deleteCommand, connection);
					adapter.InsertCommand = new SqlCommand(insertCommand, connection);
					adapter.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
					adapter.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
					adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;

					try
					{
						connection.Open();
						adapter.Update(cachedData.Tables[tableName]);
						cachedData.Tables[tableName].AcceptChanges(); // Very important: accept changes after update
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Error updating table '{tableName}': {ex.Message}");
					}
					finally
					{
						connection.Close();
					}
				}
			}
		}
		public void AddRow(string tableName, DataRow row)
		{
			if (!cachedData.Tables.Contains(tableName))
			{
				throw new ArgumentException($"Table '{tableName}' not found in the cache.");
			}

			cachedData.Tables[tableName].Rows.Add(row);
		}
	}
}
