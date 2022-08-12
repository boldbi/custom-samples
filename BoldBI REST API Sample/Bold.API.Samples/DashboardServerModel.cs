using Bold.API.Samples.DTO;
using Bold.API.Samples.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bold.API.Samples
{
    public class DashboardServerModel
    {
        private readonly DashboardServerApiClient dashboardServerApiClient;

        private readonly string _siteIdentifier;

        public DashboardServerModel(Uri dns, string siteIdentifier, string username, string password)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = dns
            };

            _siteIdentifier = siteIdentifier;

            dashboardServerApiClient = new DashboardServerApiClient(httpClient, _siteIdentifier, username, password);
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest user)
        {
            var response = new CreateUserResponse();

            try
            {
                var httpResponse = await dashboardServerApiClient.RequestExecutorAsync(HttpMethod.Post, BoldApiEndPoints.BoldBICreateUser(_siteIdentifier), user) as HttpResponseMessage;

                if (httpResponse.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<CreateUserResponse>(await httpResponse.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return response;
        }

        public async Task<GroupResponse> CreateGroupAsync(CreateGroupRequest group)
        {
            var response = new GroupResponse();

            try
            {
                var httpResponse = await dashboardServerApiClient.RequestExecutorAsync(HttpMethod.Post, BoldApiEndPoints.BoldBICreateGroup(_siteIdentifier), group) as HttpResponseMessage;

                if (httpResponse.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<GroupResponse>(await httpResponse.Content.ReadAsStringAsync());
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return response;
        }

        public async Task<ApiResponse> AddGroupPermissionAsync(GroupPermissionRequest groupPermissionRequest)
        {
            var response = new ApiResponse();

            try
            {
                var httpResponse = await dashboardServerApiClient.RequestExecutorAsync(HttpMethod.Post, BoldApiEndPoints.BoldBIAddGroupPermission(_siteIdentifier), groupPermissionRequest) as HttpResponseMessage;

                if (httpResponse.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<ApiResponse>(await httpResponse.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return response;
        }

        public async Task<ApiResponse> AddGroupMemberAsync(int groupId, AddGroupMembers groupMembers)
        {
            var response = new ApiResponse();

            try
            {
                var httpResponse = await dashboardServerApiClient.RequestExecutorAsync(HttpMethod.Post, BoldApiEndPoints.BoldBIAddGroupMember(_siteIdentifier, groupId), groupMembers) as HttpResponseMessage;

                if (httpResponse.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<ApiResponse>(await httpResponse.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return response;
        }
    }
}
