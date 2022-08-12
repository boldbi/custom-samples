using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bold.API.Samples.DTO
{
    public class CreateUserResponse : ApiResponse
    {
        [JsonProperty("Data")]
        public int UserId { get; set; }
    }
}
