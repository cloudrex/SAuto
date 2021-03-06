﻿using Newtonsoft.Json;
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
            // Program.CreateRequest<GetUserByUsernamePayload>(ApiOperations.GetUserByUsername("some reachable username here (must be in same community with the user)"));
            Program.CreateRequest<SendMessagePayload>(ApiOperations.SendMessage("hello world", "some thread id here"));

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

            HttpRequestMessage request = new HttpRequestMessage(operation.Method, API.API.BaseUrl);

            request.Content = new StringContent(JsonConvert.SerializeObject(operation), Encoding.UTF8, "application/json");

            client.SendAsync(request).ContinueWith(async (responseTask) =>
            {
                Console.WriteLine("Response: {0}", responseTask.Result);

                string body = await responseTask.Result.Content.ReadAsStringAsync();

                Console.WriteLine("Response body: {0}", body);

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    ApiResponse<GetUserByUsernameResponse> response = JsonConvert.DeserializeObject<ApiResponse<GetUserByUsernameResponse>>(body);

                    Console.WriteLine("User is: {0}", JsonConvert.SerializeObject(response.Data.User));
                }
            });
        }
    }
}
