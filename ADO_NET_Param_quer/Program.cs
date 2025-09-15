// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO_NET
{
	class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

			using (IDatabaseService dbService = new DatabaseService(connectionString)) //Using statement will ensure the connection is closed, it implements IDisposable
			{
				Console.Write("Enter first_name to search: ");
				string searchFirstName = Console.ReadLine();

				List<Dictionary<string, object>> directors = dbService.SelectDirectorsByFirstName(searchFirstName);

				foreach (var director in directors)
				{
					foreach (var kvp in director)
					{
						Console.Write($"{kvp.Key}: {kvp.Value}\t");
					}
					Console.WriteLine();
				}

				Console.Write("Enter first_name: ");
				string first_name = Console.ReadLine();

				Console.Write("Enter last_name: ");
				string last_name = Console.ReadLine();

				dbService.Insert("Directors", new Dictionary<string, string>()
				{
					{ "director_id", (Convert.ToInt32(dbService.Scalar("SELECT MAX(director_id) FROM Directors")) + 1).ToString() },
					{ "first_name", first_name },
					{ "last_name", last_name }
				});

				List<Dictionary<string, object>> allDirectors = dbService.Select("*", "Directors");
				foreach (var director in allDirectors)
				{
					foreach (var kvp in director)
					{
						Console.Write($"{kvp.Key}: {kvp.Value}\t");
					}
					Console.WriteLine();
				}
			}
		}
	}
}
