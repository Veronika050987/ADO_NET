// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO_NET
{
	class Program
	{
		static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies;" +
			"Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
			"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		static void Main(string[] args)
		{
			using (Connector db = new Connector(connectionString))
			{
				InsertMovie(db);
			}
		}

		static void InsertMovie(Connector db)
		{
			Console.Write("Movie name: ");
			string movie_name = Console.ReadLine();
			Console.Write("Release date: ");
			string release_date = Console.ReadLine();
			Console.Write("Director: ");
			string director = Console.ReadLine();

			db.Insert
				("Movies",
				"movie_id,movie_name,release_date,director",
				$"{Convert.ToInt32(db.Scalar("SELECT MAX(movie_id) FROM Movies")) + 1},N'{movie_name}'," +
				$"N'{release_date}',{GetDirectorID(director, db)}"
				);

			foreach (var item in db.Select
				(
				"movie_name,release_date,first_name,last_name",
				"Movies,Directors",
				"director=director_id"
				))
			{
				foreach (var prop in item)
				{
					Console.WriteLine($"{prop.Key}: {prop.Value}");
				}
			}
		}

		static int GetDirectorID(string full_name, Connector db)
		{
			return Convert.ToInt32(
				db.Scalar
				(
					$"SELECT director_id FROM Directors WHERE first_name=N'{full_name.Split(' ').First()}' " +
					$"AND last_name=N'{full_name.Split(' ').Last()}'"
				)
			);
		}

	}
}
