using Newtonsoft.Json;

namespace SAuto.API
{
    public struct MessageContent
    {
        [JsonProperty("body")]
        public string Body { get; set; }
    }
    public struct Message
    {
        [JsonProperty("content")]
        public MessageContent Content { get; set; }

        [JsonProperty("messageType")]
        public string Type { get; set; }

        // TODO: Investigate type
        [JsonProperty("parentId")]
        public dynamic ParentId { get; set; }

        [JsonProperty("threadId")]
        public string ThreadId { get; set; }

        [JsonProperty("threadType")]
        public string ThreadType { get; set; }
    }

    public struct GetUserByUsernamePayload
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public struct SendMessagePayload
    {
        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}
