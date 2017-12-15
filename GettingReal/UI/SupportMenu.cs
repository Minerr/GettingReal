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
			Console.WriteLine("2. Show all consents");
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
				//case "2":
				//	ShowAllConsent();
				//	break;
				//case "3":
				//	ShowAllActiveConsent();
				//	break;
				//case "4":
				//	RevokeConsent();
				//	break;
				default:
					Console.WriteLine("Wrong choice, try again");
					break;
			}

			Console.Write("Press any key to continue...");
			Console.ReadKey();
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

		private void ShowAllPermissions()
		{
			//     List<object[]> allPermissions = PermissionAPI.RetrieveAllPermissions();

			//     foreach (object[] permission in allPermissions)
			//     {
			//      for (int i = 0; i < permission.Length; i++)
			//      {
			//	Console.WriteLine("Det er er permission");
			//}
			//     }
		}

		private void ShowAllConsent()
		{
			
		}

		private void ShowAllActiveConsent()
		{
			
		}

		private void RevokeConsent()
		{
			
		}


	}
}