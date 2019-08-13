using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TlsCheckFramework461
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Target Framework: 4.6.1");
                Console.WriteLine($"Environment.Version: {Environment.Version}");
                Console.WriteLine($"ServicePointManager.SecurityProtocol: {ServicePointManager.SecurityProtocol}");

                var client = new HttpClient();
                var config = await client.GetStringAsync("https://www.howsmyssl.com/a/check");

                Console.WriteLine();
                Console.WriteLine(config);
                Console.WriteLine();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Exception: {ex.InnerException.Message}");
                Console.WriteLine($"Exception: {ex.InnerException.InnerException.Message}");
            }

            Console.WriteLine("Done.");

            if (Debugger.IsAttached)
            {
                Console.ReadKey();
            }
        }
    }
}
