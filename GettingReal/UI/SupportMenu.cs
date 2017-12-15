using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;

namespace UI
{
    public class SupportMenu : IMenu
    {
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

        public void HandleInput(string input)
        {
            switch (input)
            {
                case "1":
					NewPermissionRequest();
                    break;
                default:
					Console.WriteLine("Wrong choice, try again");
                    break;
            }
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
		}

		private void NewPermissionRequest()
		{
			ShowAllPermissions();



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

        private void SupportMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Support Menu");
            Console.WriteLine("");
            Console.WriteLine("1. New permission request");
			Console.WriteLine("2. Show all consents");
			Console.WriteLine("3. Show all active consents");
			Console.WriteLine("4. Revoke consent");
        }

    }
}
