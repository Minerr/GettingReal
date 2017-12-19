using Application;
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
				    ShowActiveConsent();
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
		    throw new NotImplementedException();
	    }

	    private void ShowActiveConsent()
	    {
		    throw new NotImplementedException();
	    }

	    private void ShowPendingPermissionRequests()
	    {
			GUIHandler.PrintTable(ConsentAPI.RetrieveRequestResponses(Convert.ToInt32(this.userID)));
	    }

	    private void ShowAllPermissions()
        {
            Console.WriteLine("This is customer menu");
        }
    }
}
