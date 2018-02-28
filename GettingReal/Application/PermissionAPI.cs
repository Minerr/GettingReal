using System;
using System.Collections.Generic;
using GettingReal;
using System.IO;

namespace Application
{
    public static class PermissionAPI
    {
		public static string RetrieveAllPermissions()
		{
			return DomainController.Instance.RetrieveAllPermissions();
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

