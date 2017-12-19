using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
	public static class FileHandler
	{

		public static void SaveFile(string path, string fileData, string fileName)
		{
			try
			{
				DirectoryInfo di = Directory.CreateDirectory(path); // Create folder if it does not exists.

				path += "\\" + fileName + ".txt"; // Set name and datatype for the file.

				File.WriteAllText(path, fileData); //Create the file using the path and content.
			}
			catch(Exception e)
			{
				Console.WriteLine("Could not create file!", e.ToString());
			}
		}

		public static string RetrieveFile(string path, string fileName)
		{
			string fileData = null;

			try
			{
				path += "\\" + fileName + ".txt"; // Set name and datatype for the file.
				fileData = File.ReadAllText(path);
			}
			catch(Exception e)
			{
				Console.WriteLine("Could not create file!", e.ToString());
			}

			return fileData;
		}
		public static string[] RetrieveAllFilesInFolder(string path)
		{
			string[] fileData = null;

			if(Directory.Exists(path))
			{
				string[] filePaths = Directory.GetFiles(path);

				fileData = new string[filePaths.Length];

				for(int i = 0; i < fileData.Length; i++)
				{
					fileData[i] = File.ReadAllText(filePaths[i]);
				}
			}

			return fileData;
		}

	}
}
