using System;
using System.Collections.Generic;
using GettingReal;

namespace Application
{
    public static class ConsentAPI
    {
        public static List<object[]> SaveConsent(int userID, int permissionID, DateTime expirationTime)
        {
            Dictionary<string, object> parameterInput = new Dictionary<string, object>();

            parameterInput.Add("UserID", userID);
            parameterInput.Add("PermissionID", permissionID);
            parameterInput.Add("ExpirationTime", expirationTime);

            return ConsentDatabaseController.RetrieveQuery("SaveConsent", parameterInput);
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
	}
}