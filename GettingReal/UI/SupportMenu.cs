using System;
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
				if(instance == null)
				{
					instance = new SupportMenu();
				}

				return instance;
			}
		}

		public void ShowMenu()
		{
			ShowAllPermissions();
		}

		public void HandleInput(string input)
		{
			
		}

		private void ShowAllPermissions()
		{
			Console.WriteLine("This is support menu");
		}
	}
}
