using System;
using System.Collections.Generic;
using GettingReal;

namespace Application
{
    public static class ConsentAPI
    {
        public static string SaveConsent(int userID, int permissionID, DateTime expirationTime)
        {
			return DomainController.Instance.SaveConsent(userID, permissionID, expirationTime);
		}

	    public static string RetrieveAllConsents(int userID)
	    {
			return DomainController.Instance.RetrieveAllConsents(userID);		
	    }

		public static string RevokeConsent(int userID, int permissionID)
	    {
			return DomainController.Instance.RevokeConsent(userID, permissionID);
	    }

		public static string RetrieveRequestResponses(int userID)
		{
			return DomainController.Instance.RetrieveRequestResponse(userID);
		}

		public static string CheckForConsent(int userID, int permissionID)
		{
			return DomainController.Instance.CheckForConsent(userID, permissionID);
		}
	}

}