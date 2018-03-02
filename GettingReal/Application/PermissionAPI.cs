using System;
using System.Collections.Generic;
using System.IO;
using Domain;

namespace Application
{
    public static class PermissionAPI
    {
		public static List<string[]> RetrieveAllPermissions(out string outputMessage)
		{
			return Converter.ConvertToStringArrayList(PermissionDomainController.Instance.RetrieveAllPermissions(out outputMessage));
		}

		public static List<string[]> RetrieveRequestResponses(int userID, out string outputMessage)
		{
			return Converter.ConvertToStringArrayList(PermissionDomainController.Instance.RetrieveRequestResponse(userID, out outputMessage));
		}

		public static string CreatePermissionRequest(string userID, string permissionID, string duration)
		{
			string result = "Permission request could not be created.";

			//string path = @"c:\GettingReal\Customers\" + userID;
			//string fileData = permissionID + ";" + duration;
			//string fileName = "request" + permissionID;

			//try
			//{
			//	FileHandler.SaveFile(path, fileData, fileName);
			//}
			//catch(Exception e)
			//{
			//	result = "ERROR! " + e.Message;
			//}

			return result;
		}

	}
}

