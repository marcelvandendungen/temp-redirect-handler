using Microsoft.AspNetCore.Hosting;
using System;

namespace SelfHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                new WebHostBuilder()
                    .UseKestrel()
                    .UseUrls(args[0])
                    .UseStartup<Startup>()
                    .Build()
                    .Run();
            }
            else
            {
                Console.WriteLine("Please specify the listening address as an argument");
            }
        }
    }
}
