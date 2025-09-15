// DatabaseService.cs (C# Class)
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO_NET
{
	public class DatabaseService : IDatabaseService
	{
		//Constants and Variables.
		private bool disposedValue;
		public string ConnectionString { get; }
		public SqlConnection Connection { get; private set; }  //Declare connection here.

		//Constructor
		public DatabaseService(string connectionString)
		{
			ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
			Connection = new SqlConnection(ConnectionString);
		}

		//Select by First Name
		public List<Dictionary<string, object>> SelectDirectorsByFirstName(string firstName)
		{
			List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

			try
			{
				Connection.Open();

				string cmd = "SELECT * FROM Directors WHERE first_name = @FirstName;"; // Use parameterized query
				SqlCommand command = new SqlCommand(cmd, Connection);
				command.Parameters.AddWithValue("@FirstName", firstName); // Prevent SQL injection.

				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Dictionary<string, object> row = new Dictionary<string, object>();
						for (int i = 0; i < reader.FieldCount; i++)
						{
							row.Add(reader.GetName(i), reader[i]);
						}
						results.Add(row);
					}
				}
			}
			finally
			{
				Connection.Close();
			}
			return results;
		}

		//Select statement
		public List<Dictionary<string, object>> Select(string fields, string tables, string condition = "")
		{
			List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
			try
			{
				Connection.Open();

				string cmd = $"SELECT {fields} FROM {tables}";
				if (!string.IsNullOrEmpty(condition)) cmd += $" WHERE {condition}";

				using (SqlCommand command = new SqlCommand(cmd, Connection))
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Dictionary<string, object> row = new Dictionary<string, object>();
						for (int i = 0; i < reader.FieldCount; i++)
						{
							row.Add(reader.GetName(i), reader[i]);
						}
						results.Add(row);
					}
				}
			}
			finally
			{
				Connection.Close();
			}
			return results;
		}

		//Scalar statement
		public object Scalar(string cmd)
		{
			try
			{
				Connection.Open();
				SqlCommand command = new SqlCommand(cmd, Connection);
				return command.ExecuteScalar();
			}
			finally
			{
				Connection.Close();
			}
		}

		//Insert statement
		public void Insert(string table, Dictionary<string, string> values)
		{
			try
			{
				Connection.Open();

				StringBuilder columns = new StringBuilder();
				StringBuilder vals = new StringBuilder();

				foreach (var kvp in values)
				{
					columns.Append(kvp.Key).Append(",");
					vals.Append("N'").Append(kvp.Value).Append("',");
				}

				columns.Length--; // Remove trailing comma
				vals.Length--; // Remove trailing comma

				string cmd = $"INSERT {table} ({columns}) VALUES ({vals})";

				using (SqlCommand command = new SqlCommand(cmd, Connection))
				{
					command.ExecuteNonQuery();
				}
			}
			finally
			{
				Connection.Close();
			}
		}


		// Implemented IDisposable
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// Dispose managed state (managed objects)
					Connection?.Dispose(); // Dispose of the SqlConnection if it's not null
				}

				// Free unmanaged resources (unmanaged objects) and override finalizer
				// Set large fields to null
				disposedValue = true;
			}
		}

		~DatabaseService()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);//Garbage Collection
		}
	}
}
