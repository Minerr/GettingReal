using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
	public class SupportMenuViewModel
	{
		public int UserID { get; set; }
		public int PermissionID { get; set; }

		public List<Permission> PermissionList { get; set; }
		public Permission Permission { get; set; }
		public int PermissionDuration { get; set; }

		public SupportMenuViewModel()
		{
			PermissionList = new List<Permission>();
		}

		public void AddPermissionToList(int permissionID, string legalText)
		{
			PermissionList.Add(new Permission(permissionID, legalText));
		}

		public void ClearPermissionList()
		{
			PermissionList.Clear();
		}

	}
}
