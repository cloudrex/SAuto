using Newtonsoft.Json;

namespace SAuto.Structures
{
    public struct User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("profilePhoto")]
        public string AvatarUrl { get; set; }

        [JsonProperty("coverPhoto")]
        public string CoverUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("isOnline")]
        public bool Online { get; set; }

        // TODO: Investigate type
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("totalReputation")]
        public int TotalReputation { get; set; }

        // TODO: Investigate type
        [JsonProperty("betaSupporter")]
        public string BetaSupporter { get; set; }
    }
}
