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
		public Permission SelectedPermission { get; set; }
		public int PermissionDuration { get; set; }

		public List<Consent> ConsentList { get; set; }
		public Consent SelectedConsent { get; set; }


		public SupportMenuViewModel()
		{
			PermissionList = new List<Permission>();
			ConsentList = new List<Consent>();
		}


		public void AddPermissionToList(int permissionID, string legalText)
		{
			PermissionList.Add(new Permission(permissionID, legalText));
		}

		public void ClearPermissionList()
		{
			PermissionList.Clear();
		}


		public void AddConsentToList(int userID, int permissionID, DateTime createdTime, DateTime expiredTime, string legalText)
		{
			ConsentList.Add(new Consent(userID, permissionID, createdTime, expiredTime, legalText));
		}

		public void ClearConsentList()
		{
			ConsentList.Clear();
		}

		internal void RemoveConsentFromList(Consent consent)
		{
			ConsentList.Remove(consent);
			SelectedConsent = null;
		}
	}
}
