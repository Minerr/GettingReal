using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
	public class MenuHandler : IMenu
	{
		public enum MenuType
		{
			MainMenu,
			SupportMenu,
			CustomerMenu
		}

		private static MenuHandler instance;

		public static MenuHandler Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new MenuHandler();
				}

				return instance;
			}
		}
		
		private MenuType currentMenu;

		private MenuHandler()
		{
			currentMenu = MenuType.MainMenu;
		}

		public void ShowMenu()
		{
			GetMenu().ShowMenu();
		}

		public void HandleInput(string input)
		{
			GetMenu().HandleInput(input);
		}
	
		private IMenu GetMenu()
		{
			switch(currentMenu)
			{
				case MenuType.MainMenu:
					return MainMenu.Instance;
				case MenuType.SupportMenu:
					return SupportMenu.Instance;
				// TODO: Implement CustomerMenu class
				//case MenuType.CustomerMenu:
				//	return CustomerMenu.Instance;
				default:
					return MainMenu.Instance;
			}
		}

		public void ChangeCurrentMenu(MenuType menuType)
		{
			currentMenu = menuType;
		}
	}
}
