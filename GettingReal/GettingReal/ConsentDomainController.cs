using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class ConsentDomainController
	{
		//Singleton
		private static ConsentDomainController instance;
		public static ConsentDomainController Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new ConsentDomainController();
				}

				return instance;
			}
		}

		private ConsentDomainController()
		{

		}

		public string SaveConsent(int userID, int permissionID, DateTime expirationTime)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();

			parameterInput.Add("UserID", userID);
			parameterInput.Add("PermissionID", permissionID);
			parameterInput.Add("ExpirationTime", expirationTime);

			string errorMessage = ConsentDatabaseController.ExecuteNonQuery("SaveConsent", parameterInput);

			if(errorMessage == "")
			{
				return "Success! Consent was created!";
			}

			return errorMessage;
		}

		public bool CheckForConsent(int userID, int permissionID, out string outputMessage)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();

			parameterInput.Add("UserID", userID);
			parameterInput.Add("PermissionID", permissionID);

			bool result = ConsentDatabaseController.CheckQuery("CheckConsent", parameterInput, out outputMessage);

			if(outputMessage == "")
			{
				if(result)
				{
					outputMessage = "User nr: " + userID + ", has given consent to the permission.";
				}
				else
				{
					outputMessage = "User nr: " + userID + ", has not given consent to the permission.";
				}
			}

			return result;
		}

		public List<Consent> RetrieveAllConsents(int userID, out string outputMessage)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();
			parameterInput.Add("UserID", userID);

			return ConvertTableToList(ConsentDatabaseController.RetrieveQuery("RetrieveAllConsents", parameterInput, out outputMessage));
		}

		public string RevokeConsent(int userID, int permissionID)
		{
			Dictionary<string, object> parameterInput = new Dictionary<string, object>();

			parameterInput.Add("UserID", userID);
			parameterInput.Add("PermissionID", permissionID);

			string outputMessage = ConsentDatabaseController.ExecuteNonQuery("RevokeConsent", parameterInput);

			if(outputMessage == "")
			{
				outputMessage = "Consent with permission ID: " + permissionID + ", has been revoked from user nr: " + userID + ".";
			}

			return outputMessage;
		}

		private List<Consent> ConvertTableToList(List<object[]> table)
		{
			List<Consent> list = new List<Consent>();

			foreach(object[] row in table.Skip(1))
			{
				list.Add(new Consent(row));
			}

			return list;
		}
	}
}
