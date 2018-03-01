using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
	public class Consent
	{
		public int UserID { get; set; }
		public int PermissionID { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime ExpirationTime { get; set; }
		public string LegalText { get; set; }

		public Consent(int userID, int permissionID, DateTime createdTime, DateTime expirationTime, string legalText)
		{
			UserID = userID;
			PermissionID = permissionID;
			CreatedTime = createdTime;
			ExpirationTime = expirationTime;
			LegalText = legalText;
		}

	}
}
