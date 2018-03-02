using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
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

		public List<Permission> RetrieveAllPermissions(out string outputMessage)
		{
			return ConvertTableToList(ConsentDatabaseController.RetrieveQuery("RetrieveAllPermissions", new Dictionary<string, object>(), out outputMessage));
		}

		public List<PermissionRequest> RetrieveRequestResponse(int userID, out string outputMessage)
		{
			List<string[]> table = new List<string[]>();

			string path = @"c:\GettingReal\Customers\" + userID;
			string[] allFileData = FileHandler.RetrieveAllFilesInFolder(path);

			if(allFileData != null)
			{
				for(int i = 0; i < allFileData.Length; i++)
				{
					string[] fileValues = allFileData[i].Split(';');
					table.Add(fileValues);
				}

				outputMessage = "Retrieving request responses was a success!";
				return ConvertFileDataToList(table);
			}

			outputMessage = "Failed retrieving request responses!";
			return new List<PermissionRequest>();
		}

		private List<Permission> ConvertTableToList(List<object[]> table)
		{
			List<Permission> list = new List<Permission>();

			foreach(object[] row in table.Skip(1))
			{
				list.Add(new Permission(row));
			}

			return list;
		}

		private List<PermissionRequest> ConvertFileDataToList(List<string[]> table)
		{
			List<PermissionRequest> list = new List<PermissionRequest>();

			foreach(string[] row in table)
			{
				list.Add(new PermissionRequest(row));
			}

			return list;
		}
	}
}
