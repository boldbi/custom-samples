using Bold.API.Samples.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Bold.API.Samples
{
    public class TenantManagementApiClient
    {
        private HttpClient _httpClient;

        private static Token OAuthAuthentication;

        private readonly string _clientId;

        private readonly string _clientSecret;

        public TenantManagementApiClient(HttpClient httpClient, string clientId, string clientSecret)
        {
            this._httpClient = httpClient;
            this._clientId = clientId;
            this._clientSecret = clientSecret;
        }

        private Token GetAccessToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BoldApiEndPoints.UmsTokenEndPoint);

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", _clientId),
                new KeyValuePair<string, string>("client_secret", _clientSecret)
            };

            request.Content = new FormUrlEncodedContent(keyValues);

            var response = _httpClient.SendAsync(request).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            OAuthAuthentication = JsonConvert.DeserializeObject<Token>(result);

            OAuthAuthentication.ExpiresOn = DateTime.UtcNow.AddSeconds(OAuthAuthentication.ExpiresIn.HasValue ? OAuthAuthentication.ExpiresIn.Value - 600 : 3000);

            return OAuthAuthentication;
        }

        public async Task<object> RequestExecutorAsync<T>(HttpMethod httpMethod, string endpoint, T data)
        {
            var responseObject = new object();

            try
            {
                if (OAuthAuthentication == null || (OAuthAuthentication != null && OAuthAuthentication.ExpiresOn < DateTime.UtcNow))
                {
                    OAuthAuthentication = GetAccessToken();
                }

                var jsonData = data != null ? data.AsJson() : new StringContent(string.Empty);

                switch (httpMethod.Method)
                {
                    case "POST":
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", OAuthAuthentication.AccessToken);
                        responseObject = await _httpClient.PostAsync(endpoint, jsonData);
                        break;

                    case "GET":
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", OAuthAuthentication.AccessToken);
                        responseObject = await _httpClient.GetStringAsync(endpoint);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return responseObject;
        }
    }
}
