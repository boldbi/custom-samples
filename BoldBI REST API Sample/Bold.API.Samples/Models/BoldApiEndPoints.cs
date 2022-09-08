using System;
using System.Collections.Generic;
using System.Text;

namespace Bold.API.Samples.Models
{
    public class BoldApiEndPoints
    {
        public static string UmsTokenEndPoint => "/api/token";

        public static string CreateTenant => "/api/v2.0/tenants";

        public static string AddUser => "/api/v2.0/user/add";

        public static string BoldBITokenEndPoint(string siteIdentifier) => $"/bi/api/site/{siteIdentifier}/token";

        public static string BoldBICreateUser(string siteIdentifier) => $"/bi/api/site/{siteIdentifier}/v4.0/users";

        public static string BoldBICreateGroup(string siteIdentifier) => $"/bi/api/site/{siteIdentifier}/v4.0/groups";

        public static string BoldBIAddGroupPermission(string siteIdentifier) => $"/bi/api/site/{siteIdentifier}/v4.0/permissions/groups";

        public static string BoldBIAddGroupMember(string siteIdentifier, int groupId) => $"/bi/api/site/{siteIdentifier}/v4.0/groups/{groupId}/users";
    }
}
