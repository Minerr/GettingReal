using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
	internal static class GUIHandler
	{

		public static void PrintTableOrMessage(List<string[]> table, string message)
		{
			if(table == null)
			{
				Console.WriteLine(message);
				return;
			}

			Console.WriteLine(ConvertArrayListToString(table));
		}

		private static string ConvertArrayListToString(List<string[]> arrayList)
		{
			string result = "";

			foreach(string[] row in arrayList)
			{
				string columnValues = "";
				foreach(string value in row)
				{
					columnValues += value + "    ";
				}

				result += columnValues + "\n";
			}

			return result;
		}
	}
}
