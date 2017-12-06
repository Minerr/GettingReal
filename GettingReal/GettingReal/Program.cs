using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
	public class Program
	{
		static void Main(string[] args)
		{
			List<object[]> table = ConsentDatabaseController.RetrieveQuery("GetPets", new Dictionary<string, object>());
			
			foreach(object[] row in table)
			{
				string sRow = "";

				foreach(object column in row)
				{
					sRow += column + " ";
				}

				Console.WriteLine(sRow);
			}

			Console.ReadKey();
		}
	}
}
