using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
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
	}
}
