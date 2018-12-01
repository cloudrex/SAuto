using Newtonsoft.Json;
using SAuto.Structures;

namespace SAuto.API
{
    public struct ApiResponse<PayloadType>
    {
        [JsonProperty("data")]
        public PayloadType Data { get; set; }
    }

    public struct GetUserByUsernameResponse
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }
}
