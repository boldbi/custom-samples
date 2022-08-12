using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bold.API.Samples.DTO
{
    public partial class ApiResponse
    {
        [JsonProperty("ApiStatus")]
        public bool ApiStatus { get; set; }

        [JsonProperty("Status")]
        public bool Status { get; set; }

        [JsonProperty("StatusMessage")]
        public string StatusMessage { get; set; }
    }
}
