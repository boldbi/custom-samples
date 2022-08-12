using Bold.API.Samples.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using static Bold.API.Samples.DTO.EnumClass;

namespace Bold.API.Samples
{
    internal class Program
    {

        private static Uri dns = new Uri("http://localhost:61810");

        // To manage sites, we need to authenticate using the client id and secret. Please refer to this document to get REST API Credentials - https://help.boldbi.com/embedded-bi/multi-tenancy/site-administration/api-keys/
        private const string clientId = "bbe529d3-dbb3-4084-b8f7-0812c708a539";

        private const string clientSecret = "NioN896TkUJBe0AwO2BYF3f/kGWpTe4i5+MK2eZb23kSOgQwCM9ecaXXtK9c2iG7yJZpuI79ZZlk8cnQ7Im3ww==";

        // To perform site specific operation, we need to authenticate with the username and password. This user account should have admin access in the site.
        private const string username = "apitesting@boldbi.localhost";

        private const string password = "Test@123";

        // This is the identifier of the site/tenant where we need to add the users, groups. In this sample, we have created a new site and added users, groups
        private const string siteIdentifier = "api-test";

        static void Main(string[] args)
        {
            var tenantManagement = new TenantManagementModel(dns, clientId, clientSecret);

            #region Create Tenant

            var createTenant = new CreateTenantRequest
            {
                Email = username,
                ServerConfiguration = new ServerConfiguration
                {
                    Site = new Site
                    {
                        TenantIdentifier = siteIdentifier,
                        TenantName = "API Testing",
                        TenantType = (int)TenantType.BoldBI
                    },
                    Database = new Data // Parameters will differ based on Sql Server Type. Please refer the API document - https://help.boldbi.com/embedded-bi/rest-api-reference/site-administration/v2.0/api-reference/#tag/Tenants/operation/create_tenant
                    {
                        DatabaseName = "apitest1",
                        ServerName = "localhost",
                        UserName = "sa",
                        Password = "sa@1234",
                        ServerType = (int)SqlServerType.MSSQL,
                        IsNewDatabase = true,
                        SslEnabled = false
                    },
                    Storage = new Storage
                    {
                        StorageType = (int)StorageType.FileStorage
                    }
                },
                DataStoreConfiguration = new Data // Parameters will differ based on Sql Server Type. Please refer the API document - https://help.boldbi.com/embedded-bi/rest-api-reference/site-administration/v2.0/api-reference/#tag/Tenants/operation/create_tenant
                {
                    DatabaseName = "apitest1imdb",
                    ServerName = "localhost",
                    UserName = "sa",
                    Password = "sa@1234",
                    ServerType = (int)SqlServerType.MSSQL,
                    IsNewDatabase = true,
                },
            };

            var createTenantResponse = tenantManagement.CreateTenantAsync(createTenant).Result;

            #endregion

            var dashboardServer = new DashboardServerModel(dns, siteIdentifier, username, password);

            var currentTime = DateTime.UtcNow.ToString("yyyyMMddhhmmss");

            #region Create Group

            var newGroup = new CreateGroupRequest
            {
                Name = $"API Test Group - {currentTime}", // Group Name Should be unique
                Description = "Group has been created using REST API"
            };

            var groupResponse = dashboardServer.CreateGroupAsync(newGroup).Result;

            #endregion

            #region Add Group Permission

            var groupPermissionRequest = new GroupPermissionRequest
            {
                GroupId = groupResponse.GroupId,
                PermissionAccess = "ReadWriteDelete",
                PermissionEntity = "AllDashboards"
            };

            var groupPermission = dashboardServer.AddGroupPermissionAsync(groupPermissionRequest).Result;

            #endregion

            #region Create User

            var users = new List<int>();

            for (var i = 0; i < 5; i++)
            {
                var uniqueUsername = $"john.{DateTime.UtcNow.ToString("yyyyMMddhhmmss")}"; // To create unique username for testing

                var newUser = new CreateUserRequest
                {
                    Username = uniqueUsername, 
                    FirstName = "John",
                    Lastname = "Doe",
                    Email = $"{uniqueUsername}@example.com",
                    Password = "1qazZAQ!"
                };

                var userReponse = dashboardServer.CreateUserAsync(newUser).Result;

                users.Add(userReponse.UserId);
            }

            #endregion

            #region Add Group Members

            var groupMembersRequest = new AddGroupMembers
            {
                Id = users
            };

            var groupMembers = dashboardServer.AddGroupMemberAsync(groupResponse.GroupId, groupMembersRequest).Result;

            #endregion 

        }
    }
}
