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

		public static string CreatePermissionRequest(string userID, string permissionID, string duration)
		{
			string result = "Permission request has been created.";

			string path = @"c:\GettingReal\Customers\" + userID;
			string fileData = permissionID + ";" + duration;
			string fileName = "request" + permissionID;

			try
			{
				FileHandler.SaveFile(path, fileData, fileName);
			}
			catch(Exception e)
			{
				result = "ERROR! " + e.Message;
			}

			return result;
		}
	}
}

