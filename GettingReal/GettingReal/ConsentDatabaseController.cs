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
			"Database=DB2017_B20; " +
			"User Id=USER_B20; " +
			"Password=SesamLukOp_20;";

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
	}





}
