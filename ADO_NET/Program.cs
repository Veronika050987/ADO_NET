﻿//ADO_NET
//ADO (ActiveX Data Object) JSON, XML, MS SQL Server, MySQL, Oracle....
//#define SCALAR_CHECK
//#define ALL_IN_MAIN_CLASS
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
//ADO.NET:
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace ADO_NET
{
	class Program
	{
#if ALL_IN_MAIN_CLASS
		static string connectionString = "";
		static SqlConnection connection; 
#endif

		static void Main(string[] args)
		{
#if ALL_IN_MAIN_CLASS
			//0) Достаем строку подключения из App.config:
			connectionString = ConfigurationManager.ConnectionStrings["Movies"].ConnectionString;
			//1) Создаем подключение к Базе данных на Сервере:
			Console.WriteLine(connectionString);
			connection = new SqlConnection();
			connection.ConnectionString = connectionString;

			//Select("SELECT * FROM Directors");
			//Select("SELECT * FROM Movies");
			Select("*", "Directors");
			Select("movie_name,release_date,first_name+last_name AS Режиссер", "Movies,Directors", "director=director_id"); 
#endif

#if SCALAR_CHECK
			connection.Open();
			string cmd = "SELECT COUNT(*) FROM Directors";
			SqlCommand command = new SqlCommand(cmd, connection);
			Console.WriteLine($"Количество режиссереов:\t{command.ExecuteScalar()}");

			command.CommandText = "SELECT COUNT(*) FROM Movies";
			Console.WriteLine($"Количество киношек:\t{command.ExecuteScalar()}");

			command.CommandText = "SELECT last_name FROM Directors WHERE first_name=N'James'";
			Console.WriteLine(command.ExecuteScalar());

			connection.Close();

			Console.WriteLine(Scalar("SELECT last_name FROM Directors WHERE first_name=N'James'"));
			Console.WriteLine(Scalar("SELECT COUNT(*) FROM Movies")); 
#endif
			//InsertDirector();
			//InsertMovie();

			SongConnector song_connector =
				new SongConnector(ConfigurationManager.ConnectionStrings["Songs"].ConnectionString);

			//SongConnector connector = new SongConnector(connectionString);

			// Example:  Insert a new director
			song_connector.InsertSinger("Crash", "Adams");

			// Example: Get a list of directors
			DataTable singers = song_connector.SelectSingers();

			foreach (DataRow row in singers.Rows)
			{
				Console.WriteLine($"Singer: {row["first_name"]} {row["last_name"]}");
			}

			// Example: Insert a movie
			song_connector.InsertSong("New Heart", "2025-05-30", "Crash Adams");

			// Example: Select movies
			DataTable songs = song_connector.SelectSongs();
			foreach (DataRow row in songs.Rows)
			{
				Console.WriteLine($"Song: {row["song_name"]}, Singer: {row["first_name"]} {row["last_name"]}");
			}

			//MovieConnector movie_connector =
			//	new MovieConnector(ConfigurationManager.ConnectionStrings["Movies"].ConnectionString);
			//movie_connector.SelectDirectors();
			//movie_connector.SelectMovies();
			////movie_connector.InsertDirector();
			////movie_connector.InsertMovie();
			//movie_connector.Select("*", "Movies,Directors", "director=director_id;DROP TABLE Actors");
			////Connector connector =
			//new Connector(ConfigurationManager.ConnectionStrings["Movies"].ConnectionString);
			//connector.SelectWithParameters("James", "Cameron");

		}

	}
}
/*
CREATE TABLE [dbo].[Movies] (
    [movie_id]    INT            NOT NULL,
    [movie_name]  NVARCHAR (256) NOT NULL,
    [relese_date] DATE           NOT NULL,
    [director]    INT            NOT NULL,
    CONSTRAINT [FK_Movies_Directors] FOREIGN KEY ([director]) REFERENCES [dbo].[Directors] ([director_id]), 
    CONSTRAINT [PK_Movies] PRIMARY KEY ([movie_id])
);


 */