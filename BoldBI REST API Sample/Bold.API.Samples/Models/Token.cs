namespace Bold.API.Samples.Models
{
    using Newtonsoft.Json;
    using System;

    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken
        {
            get;
            set;
        }

        [JsonProperty("token_type")]
        public string TokenType
        {
            get;
            set;
        }

        [JsonProperty("expires_in")]
        public int? ExpiresIn
        {
            get;
            set;
        }

        [JsonProperty(".issued")]
        public string Issued { get; set; }

        [JsonProperty(".expires")]
        public DateTime ExpiresOn { get; set; }
    }
}