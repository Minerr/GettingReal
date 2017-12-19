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
				MenuHandler.ShowMenu();

				string input = Console.ReadLine();
				MenuHandler.HandleInput(input);
			}
		}
	}
}
