using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Domain
{
	internal static class ConsentDatabaseController
	{
		private static string connectionString =
			"Server=EALSQL1.eal.local; " +
			"Database=DB2017_B14; " +
			"User Id=USER_B14; " +
			"Password=SesamLukOp_14;";

		internal static string ExecuteNonQuery(string storedProcedure, Dictionary<string, object> parameterInput)
		{
			string errorMessage = "";

			using(SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();

					SqlCommand command = new SqlCommand(storedProcedure, con);
					command.CommandType = CommandType.StoredProcedure;
					foreach(KeyValuePair<string, object> parameter in parameterInput)
					{
						command.Parameters.Add(new SqlParameter("@" + parameter.Key, parameter.Value));
					}

					command.ExecuteNonQuery();
				}
				catch(SqlException e)
				{
					errorMessage = "ERROR! " + e.Message;
				}
			}

			return errorMessage;
		}

		internal static List<object[]> RetrieveQuery(string storedProcedure, Dictionary<string, object> parameterInput, out string errorMessage)
		{
			errorMessage = "";
			List<object[]> table = null;

			using(SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();

					SqlCommand command = new SqlCommand(storedProcedure, con);
					command.CommandType = CommandType.StoredProcedure;
					foreach(KeyValuePair<string, object> parameter in parameterInput)
					{
						command.Parameters.Add(new SqlParameter("@" + parameter.Key, parameter.Value));
					}

					SqlDataReader reader = command.ExecuteReader();
					table = ConvertSqlDataToList(reader);
				}
				catch(SqlException e)
				{
					errorMessage = "ERROR! " + e.Message;
				}
			}

			return table;
		}

		internal static bool CheckQuery(string storedProcedure, Dictionary<string, object> parameterInput, out string errorMessage)
		{
			errorMessage = "";
			bool result = false;

			using(SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();

					SqlCommand command = new SqlCommand(storedProcedure, con);
					command.CommandType = CommandType.StoredProcedure;
					foreach(KeyValuePair<string, object> parameter in parameterInput)
					{
						command.Parameters.Add(new SqlParameter("@" + parameter.Key, parameter.Value));
					}

					SqlDataReader reader = command.ExecuteReader();
					if(reader.HasRows)
					{
						result = true;
					}
				}
				catch(SqlException e)
				{
					errorMessage = "ERROR! " + e.Message;
				}
			}

			return result;
		}


		private static List<object[]> ConvertSqlDataToList(SqlDataReader reader)
		{
			List<object[]> table = null;

			if(reader.HasRows)
			{
				table = new List<object[]>();

				int numberOfColumns = reader.FieldCount;

				// Insert column names into the table.
				object[] columnNames = new object[numberOfColumns];
				for(int i = 0; i < numberOfColumns; i++)
				{
					columnNames[i] = reader.GetName(i);
				}
				table.Add(columnNames);

				// Insert all rows into table.
				while(reader.Read())
				{
					object[] row = new object[numberOfColumns];
					reader.GetValues(row);
					table.Add(row);
				}
			}
			return table;
		}
	}
}
