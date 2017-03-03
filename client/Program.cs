using System.Net.Http;
using System.Net.Http.Headers;
using HttpClientHandlers;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var handler = new TemporaryRedirectHandler()
            {
                InnerHandler = new HttpClientHandler()
                {
                    AllowAutoRedirect = false
                }
            };

            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer", "ABCDEF");
            var responseTask = client.GetAsync(args[0]);
            System.Console.WriteLine(responseTask.Result.Content.ReadAsStringAsync().Result);
        }
    }
}