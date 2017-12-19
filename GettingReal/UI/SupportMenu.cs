using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using System.IO;
using System.Runtime.CompilerServices;

namespace UI
{
	public class SupportMenu : IMenu
	{
		private string userID;
		private const int MAX_COLUMN_LENGTH = 40;

		private static SupportMenu instance;

		private SupportMenu()
		{
		}

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
			Console.WriteLine("3. Revoke consent");
			Console.WriteLine("4. Show request response");
		}

		public void HandleInput(string input)
		{
			switch (input)
			{
				case "1":
					NewPermissionRequest();
					break;
				case "2":
					ShowAllConsent();
					break;
				case "3":
					RevokeConsent();
					break;
				case "4":
					ShowRequestResponse();
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
			GUIHandler.PrintTable(PermissionAPI.RetrieveAllPermissions());
		}

		private void NewPermissionRequest()
		{
			ShowAllPermissions();

			Console.WriteLine("Choose permission Id");
			string permissionChoice = Console.ReadLine();
			Console.WriteLine("Define duration of permission");
			string duration = Console.ReadLine();

			if(ConsentAPI.CheckForConsent(Convert.ToInt32(this.userID), Convert.ToInt32(permissionChoice)))
			{
				Console.WriteLine("Consent for this permission has already been given for this user.");
			}
			else
			{
				PermissionAPI.CreatePermissionRequest(this.userID, permissionChoice, duration);
				Console.WriteLine("Permission request has been created.");
			}
		}

		private void ShowAllConsent()
		{
			GUIHandler.PrintTable(ConsentAPI.RetrieveAllConsents(Convert.ToInt32(this.userID)));
		}

		private void RevokeConsent()
		{
			ShowAllPermissions();

			Console.WriteLine("Enter permissionId");
			string permissionID = Console.ReadLine();

			ConsentAPI.RevokeConsent(Convert.ToInt32(this.userID), Convert.ToInt32(permissionID));
		}

		private void ShowRequestResponse()
		{
			
		}
	}
}
