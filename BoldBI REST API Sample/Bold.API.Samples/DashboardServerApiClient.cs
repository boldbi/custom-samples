using Bold.API.Samples.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Bold.API.Samples
{
    public class DashboardServerApiClient
    {
        private HttpClient _httpClient;

        private static Token OAuthAuthentication;

        private readonly string _username;

        private readonly string _password;

        private readonly string _siteIdentifier;

        public DashboardServerApiClient(HttpClient httpClient, string siteIdentifier, string username, string password)
        {
            this._httpClient = httpClient;
            this._username = username;
            this._password = password;
            this._siteIdentifier = siteIdentifier;
        }

        private Token GetAccessToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BoldApiEndPoints.BoldBITokenEndPoint(_siteIdentifier));

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", _username),
                new KeyValuePair<string, string>("password", _password)
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
