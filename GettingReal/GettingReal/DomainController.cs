using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
	public class DomainController
	{

		//Singleton
		private static DomainController instance;
		public static DomainController Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new DomainController();
				}

				return instance;
			}
		}

		private DomainController()
		{

		}

		public string SaveConsent(int userID, int permissionID, DateTime expirationTime)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();

			parameterInput.Add("UserID", userID);
			parameterInput.Add("PermissionID", permissionID);
			parameterInput.Add("ExpirationTime", expirationTime);

			return ConsentDatabaseController.ExecuteNonQuery("SaveConsent", parameterInput);
		}

		public string RetrieveRequestResponse(int userID)
		{
			List<object[]> table = new List<object[]>();

			string path = @"c:\GettingReal\Customers\" + userID;
			string[] allFileData = FileHandler.RetrieveAllFilesInFolder(path);

			if(allFileData != null)
			{
				for(int i = 0; i < allFileData.Length; i++)
				{
					string[] fileValues = allFileData[i].Split(';');
					table.Add(fileValues);
				}
			}

			return ConvertTableToString(table);
		}

		public string CheckForConsent(int userID, int permissionID)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();

			parameterInput.Add("UserID", userID);
			parameterInput.Add("PermissionID", permissionID);

			bool result = false;
			string errorMessage = ConsentDatabaseController.CheckQuery("CheckConsent", parameterInput, out result);

			if(errorMessage != "")
			{
				if(result)
				{
					return "1";
				}
				else
				{
					return "0";
				}
			}

			return errorMessage;
		}

		public string RetrieveAllPermissions()
		{
			List<object[]> table;
			string errorMessage = ConsentDatabaseController.RetrieveQuery("RetrieveAllPermissions", new Dictionary<string, object>(), out table);

			return GetTableOrError(errorMessage, table);
		}

		public string RetrieveAllConsents(int userID)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();
			parameterInput.Add("UserID", userID);

			List<object[]> table;
			string errorMessage = ConsentDatabaseController.RetrieveQuery("RetrieveAllConsents", parameterInput, out table);

			return GetTableOrError(errorMessage, table);
		}

		public string RevokeConsent(int userID, int permissionID)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();

			parameterInput.Add("UserID", userID);
			parameterInput.Add("PermissionID", permissionID);

			return ConsentDatabaseController.ExecuteNonQuery("RevokeConsent", parameterInput);
		}


		//----- private methods ---------

		private string GetTableOrError(string errorMessage, List<object[]> table)
		{
			if(table != null)
			{
				return ConvertTableToString(table);
			}

			return errorMessage;
		}

		private static string ConvertTableToString(List<object[]> table)
		{
			string printableTable = "";

			int consoleCharsPerTabs = 8;

			int numberOfColumns = table[0].Length;
			float[] tabsPerColumn = new float[numberOfColumns];

			// Find the longest sentence and calculates the number of tabs, then save that.
			foreach(object[] row in table)
			{
				for(int i = 0; i < numberOfColumns; i++)
				{
					string columnValue = Convert.ToString(row[i]);
					float stringInTabs = columnValue.Length / consoleCharsPerTabs;

					if(tabsPerColumn[i] < stringInTabs)
					{
						tabsPerColumn[i] = stringInTabs;
					}
				}
			}

			// Display each row and its column value. Insert missing tabs based on the length of the column value.
			foreach(object[] row in table)
			{
				string printableRow = "";

				for(int i = 0; i < row.Length; i++)
				{
					string columnValue = Convert.ToString(row[i]); // Dette er en kolonne i rækken.
					printableRow += columnValue; // Gem kolonne værdien til den række der skal printes ud.

					if(i != row.Length - 1) // Hvis det ikke er sidste kolonne, så indsæt tabs.
					{
						printableRow += "\t";
						float tabsForColumn =
							tabsPerColumn[i] - (columnValue.Length / consoleCharsPerTabs); //Finder hvor mange tabs der skal sættes.

						//Indsætter mellemrum som tabs, da Console har lange tabs.
						for(int tab = 0; tab <= (tabsForColumn * consoleCharsPerTabs) - 1; tab++)
						{
							printableRow += " ";
						}
					}
				}
				
				printableTable += " \n" + printableRow;
			}

			return printableTable;
		}

	}
}
