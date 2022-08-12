using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bold.API.Samples.DTO
{
    public class AddGroupMembers
    {
        [JsonProperty("Id")]
        public List<int> Id { get; set; }
    }
}
