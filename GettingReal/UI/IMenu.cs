using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
	public interface IMenu
	{
		void ShowMenu();

		void HandleInput(string input);
	}
}
