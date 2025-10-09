using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Windows.Markup;
using System.IO;

namespace Academy_PD_411
{	
	class Connector
	{
		string connectionString = "";
		SqlConnection connection = null;
		public Connector()
		{
			connectionString = ConfigurationManager.ConnectionStrings["PD_321"].ConnectionString;
			connection = new SqlConnection(connectionString);
		}
		public DataTable Select(string fields, string tables, string condition = "")
		{
			DataTable table = new DataTable();
			string cmd = $"SELECT {fields} FROM {tables}";
			if (!string.IsNullOrWhiteSpace(condition)) cmd += $" WHERE {condition}";
			cmd += ";";

			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
				table.Columns.Add(reader.GetName(i));
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++) row[i] = reader[i];
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();

			return table;
		}
		public void Insert(string table, string fields, string values)
		{
			string cmd = $"INSERT {table}({fields}) VALUES ({values})";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public void InsertTeachers(string table, string fields, params object[] values)
		{
			// 1. Validate the inputs.
			if (string.IsNullOrWhiteSpace(table))
			{
				throw new ArgumentException("Table name cannot be empty or whitespace.");
			}
			if (string.IsNullOrWhiteSpace(fields))
			{
				throw new ArgumentException("Fields cannot be empty or whitespace.");
			}

			// 2. Split the fields into an array.
			string[] fieldList = fields.Split(',');

			// 3. Validate the length.
			//if (fieldList.Length != values.Length)
			//{
			//	throw new ArgumentException("The number of fields must match the number of values.");
			//}

			// 4. Build the SQL command.
			string cmdText = $"INSERT INTO {table} ({fields}) VALUES (";

			// Add parameter names
			for (int i = 0; i < values.Length; i++)
			{
				cmdText += $"@param{i}";
				if (i < values.Length - 1)
				{
					cmdText += ", ";
				}
			}
			cmdText += ")";

			// 5. Create the SQL Command.
			using (SqlCommand command = new SqlCommand(cmdText, connection))
			{
				// 6. Set parameter values.
				for (int i = 0; i < values.Length; i++)
				{
					string paramName = $"@param{i}";
					object paramValue = values[i] ?? DBNull.Value; // Handle possible null values

					// Determine the SQL type based on the parameter value type.
					SqlDbType sqlDbType = GetSqlDbType(paramValue);

					command.Parameters.Add(paramName, sqlDbType).Value = paramValue;
				}

				// 7. Execute the SQL.
				try
				{
					connection.Open();
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					// Log the error.  Very important for debugging.
					Console.Error.WriteLine("SQL Insert Error: " + ex.Message);
					throw; // Re-throw the exception so the caller knows something went wrong.
				}
				finally
				{
					connection.Close();
				}
			}
		}

		// Helper function to determine the SQL type.
		private SqlDbType GetSqlDbType(object value)
		{
			if (value is string) return SqlDbType.NVarChar; // Or SqlDbType.VarChar, depending on your needs
			if (value is int) return SqlDbType.Int;
			if (value is short) return SqlDbType.SmallInt;
			if (value is long) return SqlDbType.BigInt;
			if (value is DateTime) return SqlDbType.DateTime;
			if (value is decimal) return SqlDbType.Decimal;
			if (value is bool) return SqlDbType.Bit;
			if (value is byte[]) return SqlDbType.VarBinary;  // For images or other binary data

			// Add more type checks as needed

			return SqlDbType.Variant; // Default to Variant (best to avoid if possible, and be specific)
		}
		public void UploadPhoto(byte[] image, int id, string field, string table)
		{

			string cmd = $"UPDATE {table} SET {field}=@image WHERE {GetPrimaryKeyName(table)}={id}";
			SqlCommand command = new SqlCommand(cmd, connection);
			command.Parameters.Add("@image", SqlDbType.VarBinary).Value = image;
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public Image DownLoadPhoto(int id, string table, string field)
		{
			Image photo = null;
			string cmd = $"SELECT {field} FROM {table} WHERE {GetPrimaryKeyName(table)}={id}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			if(reader.Read())
			{
				MemoryStream ms = new MemoryStream(reader[0] as byte[]);
				photo = Image.FromStream(ms);
			}
			connection.Close();
			return photo;
		}
		public void Update(string table, string field, string condition)
		{
			string cmd = $"UPDATE {table} SET {field} WHERE {condition}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}

		public object Scalar(string cmd)
		{
			connection.Open();
			SqlCommand command = new SqlCommand(cmd, connection);
			object obj = command.ExecuteScalar();
			connection.Close();
			return obj;
		}
		public string GetPrimaryKeyName(string table)
		{
			return Scalar
				(
				$@"SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE	OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA+'.'+QUOTENAME(CONSTRAINT_NAME)),'IsPrimaryKey')=1
AND		TABLE_NAME='{table}'"
				) as string;

		}

	}
}
