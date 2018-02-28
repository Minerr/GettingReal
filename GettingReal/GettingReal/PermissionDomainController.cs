using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
	public class PermissionDomainController
	{
		private static PermissionDomainController instance;
		public static PermissionDomainController Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new PermissionDomainController();
				}

				return instance;
			}
		}

		private PermissionDomainController()
		{

		}

		public string RetrieveAllPermissions()
		{
			List<object[]> table;
			string errorMessage = ConsentDatabaseController.RetrieveQuery("RetrieveAllPermissions", new Dictionary<string, object>(), out table);

			return DomainSharedMethods.GetTableOrError(errorMessage, table);
		}

	}
}
