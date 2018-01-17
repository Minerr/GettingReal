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
			string path = @"c:\GettingReal\Customers\" + userID;
			string fileData = permissionID + ";" + duration;
			string fileName = "request" + permissionID;

			FileHandler.SaveFile(path, fileData, fileName);
		}
	}
}

