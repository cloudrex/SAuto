using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAuto.API
{
    public struct GetUserByUsernamePayload
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
