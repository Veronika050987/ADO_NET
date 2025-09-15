//ADO_NET
//#define SCALAR_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ADO.NET:
using System.Data.SqlClient;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace ADO_NET
{
	class Program
	{
		static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		static SqlConnection connection;
		static void Main(string[] args)
		{
			//1) Создаём подключение к базу данных на сервере
			Console.WriteLine(connectionString);
			connection = new SqlConnection();
			connection.ConnectionString = connectionString;

			//Select("SELECT * FROM Directors");
			//Select("SELECT * FROM Movies");
			Select("*", "Directors");
			Select("movie_name,release_date,first_name+last_name AS Director", "Movies,Directors", "director=director_id");

#if SCALAR_CHECK
			connection.Open();
			string cmd = "SELECT COUNT(*) FROM Directors";
			SqlCommand command = new SqlCommand(cmd, connection);
			Console.WriteLine($"Directors number:\t{command.ExecuteScalar()}");

			command.CommandText = "SELECT COUNT (*) FROM Movies";
			Console.WriteLine($"Movies number:\t{command.ExecuteScalar()}");

			command.CommandText = "SELECT last_name FROM Directors WHERE first_name=N'James'";
			Console.WriteLine(command.ExecuteScalar());

			connection.Close();

			Console.WriteLine(Scalar("SELECT last_name FROM Directors WHERE first_name=N'James'"));
			Console.WriteLine(Scalar("SELECT COUNT (*) FROM Movies"));

#endif
			Console.Write("Enter first_name: ");
			string first_name = Console.ReadLine();

			Console.Write("Enter last_name: ");
			string last_name = Console.ReadLine();

			//	string cmd =
			//$"INSERT Directors(director_id,first_name,last_name) VALUES({Convert.ToInt32(Scalar("SELECT MAX(director_id) FROM Directors")) + 1},N'{first_name}',N'{last_name}');";

			//	SqlCommand command = new SqlCommand(cmd, connection);

			//	connection.Open();
			//	command.ExecuteNonQuery();
			//	connection.Close();

			//	Select("*", "Directors");

			Insert("Directors", new Dictionary<string, string>()
			{
				{ "director_id", (Convert.ToInt32(Scalar("SELECT MAX(director_id) FROM Directors")) + 1).ToString() },
				{ "first_name", first_name },
				{ "last_name", last_name }
			});

			Select("*", "Directors");
		}
		static void Select(string fields, string tables, string condition = "")
		{
			//2) Открываем соединение. После создания подключение (соединение) не является открытым. Подключение открывается вручную при необходимости
			connection.Open();

			///////////////////////

			////3) Создаём 'SqlCommand'
			string cmd = $"SELECT {fields} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			cmd += ";";
			SqlCommand command = new SqlCommand(cmd, connection);

			////4) Создаём ‘Reader’
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				Console.Write(reader.GetName(i) + "\t");
			}
			Console.WriteLine();
			while (reader.Read())
			{
				//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
				for (int i = 0; i < reader.FieldCount; i++)
					Console.Write(reader[i] + "\t\t");
				Console.WriteLine();
			}
			reader.Close();

			//////////////////////////
			//Подключение обязательно нужно закрывать.
			connection.Close();
		}
		static object Scalar(string cmd)
		{
			connection.Open();
			SqlCommand command = new SqlCommand(cmd, connection);
			object obj = command.ExecuteScalar();
			connection.Close();
			return obj;
		}

		static void Insert(string table, Dictionary<string, string> values) //correctly quotes string values to prevent SQL injection and syntax errors. It builds the INSERT statement dynamically.
		{
			StringBuilder columns = new StringBuilder();//StringBuilder to build the SQL query. 
			StringBuilder vals = new StringBuilder();

			foreach (var kvp in values)//kvp is a short, idiomatic way to refer to “key-value pair” within a foreach loop.
			{
				columns.Append(kvp.Key).Append(",");//В SQL метод append() аналогичен методу Add, но не возвращает значение после добавления элемента.
				vals.Append("N'").Append(kvp.Value).Append("',");
			}

			columns.Length--; // Remove trailing comma
			vals.Length--; // Remove trailing comma

			string cmd = $"INSERT {table} ({columns}) VALUES ({vals})";

			SqlCommand command = new SqlCommand(cmd, connection);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}

