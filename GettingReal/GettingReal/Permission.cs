using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Permission
	{
		public int PermissionID { get; set; }
		public string LegalText { get; set; }

		public Permission(int permissionID, string legalText)
		{
			PermissionID = permissionID;
			LegalText = legalText;
		}

		public Permission(object[] tableRowValues)
		{
			PermissionID = (int)tableRowValues[0];
			LegalText = (string)tableRowValues[1];
		}
	}
}
