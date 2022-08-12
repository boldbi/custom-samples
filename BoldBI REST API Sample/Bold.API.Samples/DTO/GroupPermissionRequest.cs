
namespace Bold.API.Samples.DTO
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GroupPermissionRequest
    {
        [JsonProperty("PermissionAccess")]
        public string PermissionAccess { get; set; }

        [JsonProperty("GroupId")]
        public long GroupId { get; set; }

        [JsonProperty("PermissionEntity")]
        public string PermissionEntity { get; set; }

        [JsonProperty("ItemId")]
        public string ItemId { get; set; }
    }
}
