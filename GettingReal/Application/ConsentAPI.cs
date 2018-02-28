using System;
using System.Collections.Generic;
using Domain;

namespace Application
{
    public static class ConsentAPI
    {
        public static string SaveConsent(int userID, int permissionID, DateTime expirationTime)
        {
			return ConsentDomainController.Instance.SaveConsent(userID, permissionID, expirationTime);
		}

	    public static string RetrieveAllConsents(int userID)
	    {
			return ConsentDomainController.Instance.RetrieveAllConsents(userID);		
	    }

		public static string RevokeConsent(int userID, int permissionID)
	    {
			return ConsentDomainController.Instance.RevokeConsent(userID, permissionID);
	    }

		public static string RetrieveRequestResponses(int userID)
		{
			return ConsentDomainController.Instance.RetrieveRequestResponse(userID);
		}

		public static string CheckForConsent(int userID, int permissionID)
		{
			return ConsentDomainController.Instance.CheckForConsent(userID, permissionID);
		}
	}

}