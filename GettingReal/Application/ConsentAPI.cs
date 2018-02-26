using System;
using System.Collections.Generic;
using GettingReal;

namespace Application
{
    public static class ConsentAPI
    {
        public static void SaveConsent(int userID, int permissionID, DateTime expirationTime)
        {
            Dictionary<string, object> parameterInput = new Dictionary<string, object>();

            parameterInput.Add("UserID", userID);
            parameterInput.Add("PermissionID", permissionID);
            parameterInput.Add("ExpirationTime", expirationTime);

            ConsentDatabaseController.ExecuteNonQuery("SaveConsent", parameterInput);
        }

	    public static List<object[]> RetrieveAllConsents(int userID)
	    {
		    Dictionary<string, object> parameterInput = new Dictionary<string, object>();

		    parameterInput.Add("UserID", userID);

		    return ConsentDatabaseController.RetrieveQuery("RetrieveAllConsents", parameterInput);
	    }

	    public static void RevokeConsent(int userID, int permissionID)
	    {
		    Dictionary<string, object> parameterInput = new Dictionary<string, object>();

		    parameterInput.Add("UserID", userID);
		    parameterInput.Add("PermissionID", permissionID);

		    ConsentDatabaseController.ExecuteNonQuery("RevokeConsent", parameterInput);
	    }

		public static List<object[]> RetrieveRequestResponses(int userID)
		{
			List<object[]> table = new List<object[]>();

			string path = @"c:\GettingReal\Customers\" + userID;
			string[] allFileData = FileHandler.RetrieveAllFilesInFolder(path);
			
			if(allFileData != null)
			{
				for(int i = 0; i < allFileData.Length; i++)
				{
					string[] fileValues = allFileData[i].Split(';');
					table.Add(fileValues);
				}
			}
			
			return table;
		}

		public static bool CheckForConsent(int userID, int permissionID)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();

			parameterInput.Add("UserID", userID);
			parameterInput.Add("PermissionID", permissionID);

			return ConsentDatabaseController.CheckQuery("CheckConsent", parameterInput);
		}
	}

}