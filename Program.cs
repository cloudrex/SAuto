using Newtonsoft.Json;
using SAuto.API;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SAuto
{
    public class Program
    {
        public static readonly string session = Environment.GetEnvironmentVariable("SESSION");
        public static readonly string sessionSig = Environment.GetEnvironmentVariable("SESSION_SIG");
        public static readonly string cookieDomain = ".spectrum.chat";

        public static void Main(string[] args)
        {
            Program.CreateRequest<GetUserByUsernamePayload>(ApiOperations.GetUserByUsername(Environment.GetEnvironmentVariable("TARGET_USERNAME")));

            // Don't stop
            Task.Delay(-1);
            Console.WriteLine("Program finished");
            Console.ReadKey();
        }

        public static async void CreateRequest<PayloadType>(API.ApiOperation<PayloadType> operation)
        {
            CookieContainer cookies = new CookieContainer();

            cookies.Add(new Cookie("session", Program.session, "/", Program.cookieDomain));
            cookies.Add(new Cookie("session.sig", Program.sessionSig, "/", Program.cookieDomain));

            HttpClient client = new HttpClient(new HttpClientHandler() {
                CookieContainer = cookies
            });

            client.BaseAddress = new Uri(API.API.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, API.API.BaseUrl);

            request.Content = new StringContent(JsonConvert.SerializeObject(operation), Encoding.UTF8, "application/json");

            client.SendAsync(request).ContinueWith(async (responseTask) =>
            {
                Console.WriteLine("Response: {0}", responseTask.Result);
                Console.WriteLine("Response body: {0}", await responseTask.Result.Content.ReadAsStringAsync());
            });
        }
    }
}
