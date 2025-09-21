using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
	public class Connector
	{
		private string connectionString;
		protected SqlConnection connection;

		public Connector(string connectionString)
		{
			this.connectionString = connectionString;
			connection = new SqlConnection(connectionString);
		}

		public void Insert(string table, string fields, string values)
		{
			string primary_key = Scalar
				(
				$@"SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE	OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA+'.'+QUOTENAME(CONSTRAINT_NAME)),'IsPrimaryKey')=1
AND		TABLE_NAME='{table}'"
				) as string;

			string[] fields_for_check = fields.Split(',');
			string[] values_for_check = values.Split(',');
			string condition = "";
			for (int i = 1; i < fields_for_check.Length; i++)
			{
				condition += $" {fields_for_check[i]}={values_for_check[i]} AND";
			}
			int index_of_last_space = condition.LastIndexOf(' ');
			condition = condition.Remove(index_of_last_space, 4);
			string cmd = $"IF NOT EXISTS(SELECT {primary_key} FROM {table} WHERE {condition} )BEGIN INSERT {table}({fields}) VALUES ({values}); END";

			SqlCommand command = new SqlCommand(cmd, connection);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}

		public System.Data.DataTable Select(string fields, string tables, string condition = "")
		{
			System.Data.DataTable dt = new System.Data.DataTable();

			try
			{
				connection.Open();
				string cmd = $"SELECT {fields} FROM {tables}";
				if (condition != "") cmd += $" WHERE {condition}";
				cmd += ";";
				SqlCommand command = new SqlCommand(cmd, connection);

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				adapter.Fill(dt);
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}
			return dt;
		}

		public object Scalar(string cmd)
		{
			object obj = null;
			try
			{
				connection.Open();
				SqlCommand command = new SqlCommand(cmd, connection);
				obj = command.ExecuteScalar();
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}
			return obj;
		}

		public System.Data.DataTable SelectWithParameters(string first_name, string last_name)
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			try
			{
				string cmd =
					@"
SELECT song_name,release_date,last_name,first_name 
FROM Songs,Singers 
WHERE singer=singer_id 
AND last_name=@last_name 
AND first_name=@first_name;";

				SqlCommand command = new SqlCommand(cmd, connection);
				command.Parameters.Add(new SqlParameter("@last_name", System.Data.SqlDbType.NVarChar)).Value = last_name;
				command.Parameters.Add(new SqlParameter("@first_name", System.Data.SqlDbType.NVarChar)).Value = first_name;
				connection.Open();

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				adapter.Fill(dt);
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}

			return dt;
		}
	}

	public class SongConnector : Connector
	{
		public SongConnector(string connectionString) : base(connectionString) { }

		public void InsertSong(string song_name, string release_date, string singer)
		{
			Insert
			   (
			   "Songs",
			   "song_id,song_name,release_date,singer",
			   $"{Convert.ToInt32(Scalar("SELECT ISNULL(MAX(song_id),0) FROM Songs")) + 1},N'{song_name}',N'{release_date}',{GetSingerID(singer)}"
			   );

		}

		public int GetSingerID(string full_name)
		{
			object result = Scalar
			  (
				  $"SELECT singer_id FROM Singers WHERE first_name=N'{full_name.Split(' ').First()}' AND last_name=N'{full_name.Split(' ').Last()}'"
			  );

			if (result != null && result != DBNull.Value)
			{
				return Convert.ToInt32(result);
			}
			else
			{
				return -1; // Or some other appropriate error value if singer not found.
			}
		}

		public void InsertSinger(string first_name, string last_name)
		{
			Insert
			(
				"Singers",
				"singer_id,first_name,last_name",
				$"{Convert.ToInt32(Scalar("SELECT ISNULL(MAX(singer_id),0) FROM Singers")) + 1},N'{first_name}',N'{last_name}'"
			);
		}


		public System.Data.DataTable SelectSingers()
		{
			return Select("*", "Singers");
		}

		public System.Data.DataTable SelectSongs()
		{
			return Select
				(
				"song_name,release_date,first_name,last_name",
				"Songs,Singers",
				"singer=singer_id"
				);
		}
	}
}
