// Connector.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ADO_NET
{
	public class Connector : IDisposable
	{
		private readonly string connectionString;
		private SqlConnection connection;
		private bool disposedValue;

		public Connector(string connectionString)
		{
			this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
			connection = new SqlConnection(this.connectionString);
		}

		public void Insert(string table, string fields, string values)
		{
			string primary_key = Scalar(
				$@"SELECT COLUMN_NAME
                  FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                  WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA+'.'+QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey')=1
                  AND TABLE_NAME='{table}'"
			) as string;

			Console.WriteLine("\n========================\n");
			Console.WriteLine(primary_key);
			Console.WriteLine("\n========================\n");

			string[] fields_for_check = fields.Split(',');
			string[] values_for_check = values.Split(',');
			string condition = "";
			for (int i = 1; i < fields_for_check.Length; i++)
			{
				condition += $" {fields_for_check[i]}={values_for_check[i]} AND";
			}

			int index_of_last_space = condition.LastIndexOf(' ');
			Console.WriteLine($"Condition length: {condition.Length}");
			Console.WriteLine($"Last space index: {index_of_last_space}");
			condition = condition.Remove(index_of_last_space, 4);

			string cmd = $"IF NOT EXISTS(SELECT {primary_key} FROM {table} WHERE {condition}) BEGIN INSERT {table}({fields}) VALUES({values}); END";

			using (SqlCommand command = new SqlCommand(cmd, connection))
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public List<Dictionary<string, object>> Select(string fields, string tables, string condition = "")
		{
			List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

			try
			{
				connection.Open();
				string cmd = $"SELECT {fields} FROM {tables}";
				if (!string.IsNullOrEmpty(condition)) cmd += $" WHERE {condition}";

				using (SqlCommand command = new SqlCommand(cmd, connection))
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
				connection.Close();
			}
			return results;
		}

		public string Scalar(string cmd)
		{
			try
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(cmd, connection))
				{
					object result = command.ExecuteScalar();
					return result?.ToString();  // Handle null results
				}
			}
			finally
			{
				connection.Close();
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					connection?.Dispose();
				}

				disposedValue = true;
			}
		}

		~Connector()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}