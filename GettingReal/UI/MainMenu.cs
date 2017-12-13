using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
	public class MainMenu : IMenu
	{
		private static MainMenu instance;
		private MainMenu() { }

		public static MainMenu Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new MainMenu();
				}

				return instance;
			}
		}

		public void ShowMenu()
		{
			Console.WriteLine("Choose user type:");
			Console.WriteLine("1. Support.");
			Console.WriteLine("2. Customer.");
		}

		public void HandleInput(string input)
		{
			switch(input)
			{
				case "1":
					MenuHandler.Instance.ChangeCurrentMenu(MenuHandler.MenuType.SupportMenu);
					break;
				case "2":
					MenuHandler.Instance.ChangeCurrentMenu(MenuHandler.MenuType.CustomerMenu);
					break;
			}
		}
	}
}
