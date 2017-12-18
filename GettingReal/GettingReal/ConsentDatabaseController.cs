using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GettingReal
{
	public static class ConsentDatabaseController
	{
		private static string connectionString =
			"Server=EALSQL1.eal.local; " +
			"Database=DB2017_B14; " +
			"User Id=USER_B14; " +
			"Password=SesamLukOp_14;";

		public static void ExecuteNonQuery(string storedProcedure, Dictionary<string, object> parameterInput)
		{
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
					Console.WriteLine("ERROR! " + e.Message);
				}
			}
		}

		public static List<object[]> RetrieveQuery(string storedProcedure, Dictionary<string, object> parameterInput)
		{
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
					return ConvertSqlDataToList(reader);
				}
				catch(SqlException e)
				{
					Console.WriteLine("ERROR! " + e.Message);
				}
			}

			return null;
		}

		private static List<object[]> ConvertSqlDataToList(SqlDataReader reader)
		{
			List<object[]> table = new List<object[]>();

			if(reader.HasRows)
			{
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
