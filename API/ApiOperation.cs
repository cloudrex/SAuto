using Newtonsoft.Json;

namespace SAuto.API
{
    public struct ApiOperation<PayloadType>
    {
        [JsonProperty("operationName")]
        public string Name { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("variables")]
        public PayloadType Payload { get; set; }

        [JsonIgnore]
        public RequestMethod Method { get; set; }
    }
}
