// IDatabaseService.cs (Interface Header File)
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO_NET
{
	public interface IDatabaseService : IDisposable //Inherit IDisposable, so it can be used inside a "using" statement.
													//This file defines the interface for database operations. Interfaces define a contract that implementing classes must adhere to.
													//Implementing IDisposable allows us to use the using statement, which guarantees that Dispose() is called, even if exceptions occur.
	{
		// Properties
		string ConnectionString { get; }
		SqlConnection Connection { get; }

		// Methods
		List<Dictionary<string, object>> Select(string fields, string tables, string condition = "");
		object Scalar(string cmd);
		void Insert(string table, Dictionary<string, string> values);
		List<Dictionary<string, object>> SelectDirectorsByFirstName(string firstName);
	}
}
