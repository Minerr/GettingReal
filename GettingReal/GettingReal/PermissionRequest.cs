using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class PermissionRequest
	{
		public enum RequestResponse
		{
			NotResponded,
			Accept,
			Decline
		}

		public int UserID { get; }

		public int Duration { get; }

		public RequestResponse Response { get; private set; }
		public int PermissionID { get; set; }
		public string LegalText { get; set; }

		public PermissionRequest(int userID, int permissionID, int duration, string legalText)
		{
			UserID = userID;
			Duration = duration;
			Response = RequestResponse.NotResponded;
			PermissionID = permissionID;
			LegalText = legalText;
		}
		public PermissionRequest(string[] fileDataRowValues)
		{
			UserID =			Convert.ToInt32(fileDataRowValues[0]);
			PermissionID =		Convert.ToInt32(fileDataRowValues[1]);
			Duration =			Convert.ToInt32(fileDataRowValues[2]);
			LegalText =							fileDataRowValues[3];
			string response =					fileDataRowValues[4];

			switch(response)
			{
				case "Accept":
					Response = RequestResponse.Accept;
					break;
				case "Decline":
					Response = RequestResponse.Decline;
					break;
				default:
					Response = RequestResponse.NotResponded;
					break;
			}
		}

		public void Accept()
		{
			Response = RequestResponse.Accept;
		}

		public void Decline()
		{
			Response = RequestResponse.Decline;
		}
	}
}
