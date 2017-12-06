using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public static class PermissionAPI
    {
        public static List<object[]> RetrieveAllPermissions()
        {
            return ConsentDatabaseController.RetrieveQuery("RetrieveAllPermissions", new Dictionary<string, object>());
        }
    }
}
