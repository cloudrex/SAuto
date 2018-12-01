using System.Net.Http;

namespace SAuto.API
{
    public static class API
    {
        public static string BaseUrl = "https://spectrum.chat/api";
    }

    public static class ApiOperations
    {
        public static ApiOperation<GetUserByUsernamePayload> GetUserByUsername(string username)
        {
            return new ApiOperation<GetUserByUsernamePayload>()
            {
                Name = "getUserByUsername",
                Query = "query getUserByUsername($username: LowercaseString) { user(username: $username) { ...userInfo    __typename } } fragment userInfo on User { id  profilePhoto  coverPhoto  name  firstName  description website  username isOnline  timezone  totalReputation betaSupporter __typename }",
                Method = HttpMethod.Post,

                Payload = new GetUserByUsernamePayload()
                {
                    Username = username
                }
            };
        }

        public static ApiOperation<SendMessagePayload> SendMessage(string content, string threadId)
        {
            return new ApiOperation<SendMessagePayload>()
            {
                Name = "sendMessage",
                Query = "mutation sendMessage($message: MessageInput!) { addMessage(message: $message) { ...messageInfo __typename } } fragment messageInfo on Message { id timestamp modifiedAt messageType parent { id timestamp messageType author { ...threadParticipant __typename } content { body __typename } __typename } author { ...threadParticipant __typename } reactions { count hasReacted __typename } content { body __typename } __typename } fragment threadParticipant on ThreadParticipant { user { ...userInfo __typename } isMember isModerator isBlocked isOwner roles reputation __typename } fragment userInfo on User { id profilePhoto coverPhoto name firstName description website username isOnline timezone totalReputation betaSupporter __typename } ",
                Method = HttpMethod.Post,

                Payload = new SendMessagePayload()
                {
                    Message = new Message()
                    {
                        Body = "\"{ \"blocks\":[{ \"key\":\"foo\", \"text\":\"{__CONTENT__}\", \"type\":\"unstyled\", \"depth\":0, \"inlineStyleRanges\":[], \"entityRanges\":[], \"data\":{ } }],\"entityMap\":{ } }\"".Replace("{__CONTENT__}", content)
                    }
                }
            };
        }
    }
}
