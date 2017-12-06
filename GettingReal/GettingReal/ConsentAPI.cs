using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public static class ConsentAPI
    {
        public static List<object[]> SaveConsent(int userID, int permissionID, DateTime expirationTime)
        {
            Dictionary<string, object> parameterInput = new Dictionary<string, object>();

            parameterInput.Add("UserID", userID);
            parameterInput.Add("PermissionID", permissionID);
            parameterInput.Add("ExpirationTime", expirationTime);

            return ConsentDatabaseController.RetrieveQuery("SaveConsent", parameterInput);
        }
    }
}