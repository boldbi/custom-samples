namespace Bold.API.Samples.DTO.UMS
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class UmsApiResponse
    {
        [JsonProperty("api_status")]
        public bool ApiStatus { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
    }
}
