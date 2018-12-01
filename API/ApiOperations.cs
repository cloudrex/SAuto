namespace SAuto.API
{
    public enum RequestMethod
    {
        POST,
        GET
    }

    public static class API
    {
        public static string BaseUrl = "https://spectrum.chat/api";
    }

    public static class ApiOperations
    {
        public static ApiOperation<GetUserByUsernamePayload>GetUserByUsername(string username)
        {
            return new ApiOperation<GetUserByUsernamePayload>() {
                Name = "getUserByUsername",
                Query = "query getUserByUsername($username: LowercaseString) { user(username: $username) { ...userInfo    __typename } } fragment userInfo on User { id  profilePhoto  coverPhoto  name  firstName  description website  username isOnline  timezone  totalReputation betaSupporter __typename }",
                Method = RequestMethod.POST,

                Payload = new GetUserByUsernamePayload() {
                    Username = username
                }
            };
        }
    }
}
