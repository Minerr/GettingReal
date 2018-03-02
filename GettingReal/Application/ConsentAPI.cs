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

	    public static List<string[]> RetrieveAllConsents(int userID, out string outputMessage)
	    {
			return Converter.ConvertToStringArrayList(ConsentDomainController.Instance.RetrieveAllConsents(userID, out outputMessage));		
	    }

		public static string RevokeConsent(int userID, int permissionID)
	    {
			return ConsentDomainController.Instance.RevokeConsent(userID, permissionID);
	    }

		public static bool CheckForConsent(int userID, int permissionID, out string outputMessage)
		{
			return ConsentDomainController.Instance.CheckForConsent(userID, permissionID, out outputMessage);
		}
	}

}