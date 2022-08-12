using Newtonsoft.Json;

namespace Bold.API.Samples.DTO
{
    public class GroupResponse : ApiResponse
    {
        [JsonProperty("Data")]
        public int GroupId { get; set; }
    }
}
