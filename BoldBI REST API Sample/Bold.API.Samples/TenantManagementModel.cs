using Bold.API.Samples.DTO;
using Bold.API.Samples.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bold.API.Samples
{
    public class TenantManagementModel
    {
        private readonly TenantManagementApiClient tenantManagementApiClient;

        public TenantManagementModel(Uri dns, string clientId, string clientSecret)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = dns
            };

            tenantManagementApiClient = new TenantManagementApiClient(httpClient, clientId, clientSecret);
        }

        public async Task<CreateTenantResponse> CreateTenantAsync(CreateTenantRequest createTenant)
        {
            var response = new object();

            try
            {
                response = await tenantManagementApiClient.RequestExecutorAsync<CreateTenantRequest>(HttpMethod.Post, BoldApiEndPoints.CreateTenant, createTenant);
            }
            catch (Exception ex)
            {

            }

            return JsonConvert.DeserializeObject<CreateTenantResponse>(response.ToString());
        }
    }
}
