using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Consent
	{
		public int UserID { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime ExpirationTime { get; set; }
		public int PermissionID { get; set; }
		public string LegalText { get; set; }

		public Consent(int userID, int permissionID, DateTime createdTime, DateTime expirationTime, string legalText)
		{
			UserID = userID;
			CreatedTime = createdTime;
			ExpirationTime = expirationTime;
			PermissionID = permissionID;
			LegalText = legalText;
		}

		public Consent(object[] tableRowValues)
		{
			UserID = (int) tableRowValues[0];
			PermissionID = (int) tableRowValues[1];
			CreatedTime = (DateTime) tableRowValues[2];
			ExpirationTime = (DateTime) tableRowValues[3];
			LegalText = (string) tableRowValues[4];
		}

	}
}
