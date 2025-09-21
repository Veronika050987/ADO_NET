using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyDatabaseLibrary
{
	public class Connector
	{
		private readonly string connectionString;
		private SqlConnection connection;

		public Connector(string connectionString)
		{
			try
			{
				connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
				connection = new SqlConnection(connectionString);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in Connector constructor: {ex}"); // Log the full exception!
				throw; // Re-throw the exception so the caller knows something went wrong
			}
		}

		/// <summary>
		///  Executes a scalar SQL command.
		/// </summary>
		/// <param name="cmd">The SQL command to execute.</param>
		/// <returns>The first column of the first row in the result set, or null if the result set is empty.</returns>
		public object Scalar(string cmd)
		{
			if (string.IsNullOrEmpty(cmd))
			{
				throw new ArgumentException("SQL command cannot be null or empty.", nameof(cmd));
			}

			try
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(cmd, connection))
				{
					return command.ExecuteScalar();
				}
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}
		}

		/// <summary>
		/// Inserts data into a specified table, checking for duplicates based on provided fields.
		/// </summary>
		/// <param name="table">The name of the table to insert into.</param>
		/// <param name="fields">A comma-separated string of fields to insert.</param>
		/// <param name="values">A comma-separated string of values to insert, corresponding to the fields.</param>
		/// <exception cref="ArgumentException">Thrown if table, fields, or values are null or empty.</exception>
		/// <exception cref="Exception">Thrown if there is an error executing the SQL command.</exception>
		public void Insert(string table, string fields, string values)
		{
			if (string.IsNullOrEmpty(table)) throw new ArgumentException("Table name cannot be null or empty.", nameof(table));
			if (string.IsNullOrEmpty(fields)) throw new ArgumentException("Fields cannot be null or empty.", nameof(fields));
			if (string.IsNullOrEmpty(values)) throw new ArgumentException("Values cannot be null or empty.", nameof(values));

			string primaryKey = Scalar($@"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA+'.'+QUOTENAME(CONSTRAINT_NAME)),'IsPrimaryKey')=1 AND TABLE_NAME='{table}'") as string;

			if (string.IsNullOrEmpty(primaryKey))
			{
				throw new Exception($"Primary key not found for table {table}.  Insert operation requires a primary key.");
			}


			string[] fieldsForCheck = fields.Split(',');
			string[] valuesForCheck = values.Split(',');

			if (fieldsForCheck.Length != valuesForCheck.Length)
			{
				throw new ArgumentException("The number of fields does not match the number of values.");
			}

			string condition = "";
			for (int i = 1; i < fieldsForCheck.Length; i++)
			{
				condition += $" {fieldsForCheck[i]}={valuesForCheck[i]} AND";
			}

			if (!string.IsNullOrEmpty(condition))
			{
				condition = condition.TrimEnd(" AND".ToCharArray());
			}


			string cmd = $"IF NOT EXISTS(SELECT {primaryKey} FROM {table} WHERE {condition} ) BEGIN INSERT {table}({fields}) VALUES ({values}); END";

			try
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(cmd, connection))
				{
					command.ExecuteNonQuery();
				}
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}

		}


		/// <summary>
		/// Executes a SELECT query against the database.
		/// </summary>
		/// <param name="fields">The fields to select (e.g., "id, name").</param>
		/// <param name="tables">The table(s) to select from (e.g., "Customers").</param>
		/// <param name="condition">An optional WHERE clause condition (e.g., "id = 1").</param>
		/// <exception cref="ArgumentException">Thrown if fields or tables are null or empty.</exception>
		public void Select(string fields, string tables, string condition = "")
		{
			if (string.IsNullOrEmpty(fields)) throw new ArgumentException("Fields cannot be null or empty.", nameof(fields));
			if (string.IsNullOrEmpty(tables)) throw new ArgumentException("Tables cannot be null or empty.", nameof(tables));

			string cmd = $"SELECT {fields} FROM {tables}";
			if (!string.IsNullOrEmpty(condition)) cmd += $" WHERE {condition}";
			cmd += ";";

			try
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(cmd, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						for (int i = 0; i < reader.FieldCount; i++)
						{
							Console.Write(reader.GetName(i) + "\t");
						}
						Console.WriteLine();

						while (reader.Read())
						{
							for (int i = 0; i < reader.FieldCount; i++)
								Console.Write(reader[i] + "\t\t");
							Console.WriteLine();
						}
					}
				}
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}
		}



		/// <summary>
		/// Executes a SELECT query with parameters to prevent SQL injection.
		/// </summary>
		/// <param name="firstName">The first name to search for.</param>
		/// <param name="lastName">The last name to search for.</param>
		/// <exception cref="ArgumentException">Thrown if first_name or last_name are null or empty.</exception>
		public void SelectWithParameters(string firstName, string lastName)
		{
			if (string.IsNullOrEmpty(firstName)) throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));
			if (string.IsNullOrEmpty(lastName)) throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));

			string cmd =
				@"
SELECT song_name,release_date,last_name,first_name 
FROM Songs,Singers 
WHERE singer=singer_id 
AND last_name=@last_name 
AND first_name=@first_name;";

			try
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(cmd, connection))
				{
					command.Parameters.Add(new SqlParameter("@last_name", System.Data.SqlDbType.NVarChar)).Value = lastName;
					command.Parameters.Add(new SqlParameter("@first_name", System.Data.SqlDbType.NVarChar)).Value = firstName;

					using (SqlDataReader reader = command.ExecuteReader())
					{
						for (int i = 0; i < reader.FieldCount; i++)
							Console.Write(reader.GetName(i) + "\t");
						Console.WriteLine();

						while (reader.Read())
						{
							for (int i = 0; i < reader.FieldCount; i++)
								Console.Write(reader[i] + "\t");
							Console.WriteLine();
						}
					}
				}
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}
		}
	}
}
