using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using System.IO;

namespace UI
{
	public class SupportMenu : IMenu
	{
		private string userID;
		private const int MAX_COLUMN_LENGTH = 40;

		private static SupportMenu instance;
		private SupportMenu() { }
		public static SupportMenu Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new SupportMenu();
				}

				return instance;
			}
		}

		public void ShowMenu()
		{
			SupportMainMenu();
		}

		private void SupportMainMenu()
		{
			if (userID == null)
			{
				Console.WriteLine("Support Menu");
				Console.WriteLine("");
				Console.WriteLine("Insert UserID");
				userID = Console.ReadLine();
			}

			Console.Clear();
			Console.WriteLine("Support Menu");
			Console.WriteLine("");
			Console.WriteLine("1. New permission request");
			Console.WriteLine("2. Show user consent history");
			Console.WriteLine("3. Show all active consents");
			Console.WriteLine("4. Revoke consent");
		}

		public void HandleInput(string input)
		{
			switch (input)
			{
				case "1":
					NewPermissionRequest();
					break;
				case "2":
					ShowUserConsentHistory();
					break;
				case "3":
					ShowActiveConsents();
					break;
				case "4":
					RevokeConsent();
					break;
				default:
					Console.WriteLine("Wrong choice, try again");
					break;
			}

			Console.Write("Press any key to continue...");
			Console.ReadKey();
		}

		private void ShowAllPermissions()
		{
			List<object[]> allPermissions = PermissionAPI.RetrieveAllPermissions();
			printTable(allPermissions);
		}

		private void NewPermissionRequest()
		{
			ShowAllPermissions();

			Console.WriteLine("Choose permission Id");
			string permissionChoice = Console.ReadLine();
			Console.WriteLine("Define duration of permission");
			string duration = Console.ReadLine();

			PermissionAPI.CreatePermissionRequest(this.userID, permissionChoice, duration);
		}

		private void ShowUserConsentHistory()
		{
			//Requires Logging system.
		}

		private void ShowActiveConsents()
		{
			List<object[]> activeConsents = ConsentAPI.GetActiveConsents(Int32.Parse(this.userID));
			printTable(activeConsents);
		}

		private void RevokeConsent()
		{
			printTable(new List<object[]>
			{
				new String[] { "ID", "Text", "Created", "Time" },
				new String[] { "1", "Hej med dig.", "11.05.2015", "12.05.2015" },
				new String[] { "2", "The quick brown fox jumps over the lazy dog.", "09.03.2016", "12.03.2016" },
				new String[] { "3", "Lorem Ipsum dolor sit amet.", "25.01.2017", "28.02.2017" },
				new String[] { "4", "Der indgives hvert år enorme strenge af blade af større eller mindre tilsnit.", "01.05.2017", "04.08.2017" }
			});
		}

		private void printTable(List<object[]> table)
		{
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
					string columnValue = Convert.ToString(row[i]);	// Dette er en kolonne i rækken.
					printableRow += columnValue;					// Gem kolonne værdien til den række der skal printes ud.

					if(i != row.Length - 1)	// Hvis det ikke er sidste kolonne, så indsæt tabs.
					{
						printableRow += "\t";
						float tabsForColumn = tabsPerColumn[i] - (columnValue.Length / consoleCharsPerTabs);	//Finder hvor mange tabs der skal sættes.

						//Indsætter mellemrum som tabs, da Console har lange tabs.
						for(int tab = 0; tab <= (tabsForColumn * consoleCharsPerTabs) -1; tab++)
						{
							printableRow += " ";
						}
					}
				}

				Console.WriteLine(printableRow);
			}
		}

	}
}