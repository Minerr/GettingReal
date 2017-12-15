﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    ShowAllPermissions();
                    break;
                default:
					Console.WriteLine("Wrong choice, try again");
                    break;
            }
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
		}

        private void ShowAllPermissions()
        {
            Console.WriteLine("This is support menu");
        }

        private void SupportMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Support Menu");
            Console.WriteLine("");
            Console.WriteLine("1. Show all permissions");

        }
    }
}
