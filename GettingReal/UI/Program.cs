using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{

	public class Program
	{
		static void Main(string[] args)
		{
			Program program = new Program();
			program.Run();
		}

		private void Run()
		{
			bool isRunning = true;

			while(isRunning)
			{
				ShowMenu();
				HandleInput();
			}
		}

		private void ShowMenu()
		{
			Console.Clear();
			MenuHandler.Instance.ShowMenu();

		}

		private void HandleInput()
		{
			string input = Console.ReadLine();
			MenuHandler.Instance.HandleInput(input);
		}


	}
}
