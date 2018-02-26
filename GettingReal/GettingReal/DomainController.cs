using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
	public class DomainController
	{
		public List<Consent> ListOfConsents { get; private set; }
		public List<Permission> ListOfPermissions { get; private set; }

		
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
			ListOfConsents = new List<Consent>();
			ListOfPermissions = new List<Permission>();
		}
		
		public string RetrieveAllConsents(int userID)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();
			parameterInput.Add("UserID", userID);

			List<object[]> table;
			string errorMessage = ConsentDatabaseController.RetrieveQuery("RetrieveAllConsents", parameterInput, out table);

			if(table != null)
			{
				return ConvertTableToString(table);
			}

			return errorMessage;
		}

		public static string ConvertTableToString(List<object[]> table)
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
