using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
	public static class MenuHandler
	{
		public enum MenuType
		{
			MainMenu,
			SupportMenu,
			CustomerMenu
		}

		//private static MenuHandler instance;

		//public static MenuHandler Instance
		//{
		//	get
		//	{
		//		if(instance == null)
		//		{
		//			instance = new MenuHandler();
		//		}

		//		return instance;
		//	}
		//}
		
		private static MenuType currentMenu = MenuType.MainMenu;

		//private MenuHandler()
		//{
		//	currentMenu;
		//}

		public static void ShowMenu()
		{
			Console.Clear();
			GetMenu().ShowMenu();
		}

		public static void HandleInput(string input)
		{
			GetMenu().HandleInput(input);
		}
	
		private static IMenu GetMenu()
		{
			switch(currentMenu)
			{
				case MenuType.MainMenu:
					return MainMenu.Instance;
				case MenuType.SupportMenu:
					return SupportMenu.Instance;
        		case MenuType.CustomerMenu:
				    return CustomerMenu.Instance;
				default:
					return MainMenu.Instance;
			}
		}

		public static void ChangeCurrentMenu(MenuType menuType)
		{
			currentMenu = menuType;
		}
	}
}
