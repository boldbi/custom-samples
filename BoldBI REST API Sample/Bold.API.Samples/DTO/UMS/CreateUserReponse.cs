using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bold.API.Samples.DTO.UMS
{
    public class CreateUserResponse : UmsApiResponse
    {
        [JsonProperty("data")]
        public Data UserInfo
        {
            get; set;
        }

        public partial class Data
        {
            [JsonProperty("user_id")]
            public Guid UserId { get; set; }

            [JsonProperty("user_name")]
            public string UserName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("display_name")]
            public string DisplayName { get; set; }

            [JsonProperty("contact")]
            public string Contact { get; set; }

            [JsonProperty("directory_type")]
            public DirectoryType DirectoryType { get; set; }

            [JsonProperty("email_verified")]
            public bool EmailVerified { get; set; }

            [JsonProperty("user_status")]
            public string UserStatus { get; set; }
        }

        public partial class DirectoryType
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}
