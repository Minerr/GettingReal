using System;
using System.Collections.Generic;
using GettingReal;
using System.IO;

namespace Application
{
    public static class PermissionAPI
    {
        public static List<object[]> RetrieveAllPermissions()
        {
            return ConsentDatabaseController.RetrieveQuery("RetrieveAllPermissions", new Dictionary<string, object>());
        }

		public static void CreatePermissionRequest(string userID, string permissionID, string duration)
		{
			string path = @"c:\GettingReal\" + userID;

			try
			{
				DirectoryInfo di = Directory.CreateDirectory(path);

				string fileData = permissionID + ";" + duration;
				File.WriteAllText(path, fileData);
			}
			catch(Exception e)
			{
				Console.WriteLine("Could not create permission request!", e.ToString());
			}
		}
	}
}
