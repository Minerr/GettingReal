﻿using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class CustomerMenu : IMenu
    {
	    private string userID;
        private static CustomerMenu instance;
        private CustomerMenu() { }
        public static CustomerMenu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerMenu();
                }

                return instance;
            }
        }

        public void ShowMenu()
        {
			CustomerMainMenu();
        }

	    private void CustomerMainMenu()
	    {
		    if (userID == null)
		    {
			    Console.WriteLine("Customer Menu");
			    Console.WriteLine("");
			    Console.WriteLine("Insert UserID");
			    userID = Console.ReadLine();
		    }

		    Console.Clear();
		    Console.WriteLine("Customer Menu");
		    Console.WriteLine("");
		    Console.WriteLine("1. Show pending permission requests");
		    Console.WriteLine("2. Show active consents");
		    Console.WriteLine("3. Revoke consent");
	    }

	    public void HandleInput(string input)
	    {
		    switch (input)
		    {
			    case "1":
				    ShowPendingPermissionRequests();
				    break;
			    case "2":
				    ShowActiveConsents();
				    break;
			    case "3":
				    RevokeConsent();
				    break;
			    default:
				    Console.WriteLine("Wrong choice, try again");
				    break;
		    }

		    Console.Write("Press any key to continue...");
		    Console.ReadKey();
	    }

	    private void RevokeConsent()
	    {
			ShowActiveConsents();

			Console.WriteLine("Enter permissionID to revoke corresponding consent");
			string permissionID = Console.ReadLine();
			Console.WriteLine(ConsentAPI.RevokeConsent(Convert.ToInt32(userID), Convert.ToInt32(permissionID)));
	    }

	    private void ShowActiveConsents()
	    {
			string outputMessage = "";
			List<string[]> outputList = ConsentAPI.RetrieveAllConsents(Convert.ToInt32(userID), out outputMessage);

			GUIHandler.PrintTableOrMessage(outputList, outputMessage);
		}

	    private void ShowPendingPermissionRequests()
	    {
			string outputMessage = "";
			List<string[]> outputList = PermissionAPI.RetrieveRequestResponses(Convert.ToInt32(this.userID), out outputMessage);

			GUIHandler.PrintTableOrMessage(outputList, outputMessage);
		}
    }
}
