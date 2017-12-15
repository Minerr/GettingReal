using System.Collections.Generic;
using GettingReal;

namespace Application
{
    public static class PermissionAPI
    {
        public static List<object[]> RetrieveAllPermissions()
        {
            return ConsentDatabaseController.RetrieveQuery("RetrieveAllPermissions", new Dictionary<string, object>());
        }
    }
}
