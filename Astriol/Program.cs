using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Astriol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(option =>
                    {
                        option.Listen(IPAddress.Parse("127.0.0.1"), 8000, listenOption =>
                        {
                            listenOption.Protocols = HttpProtocols.Http2;
                        });
                        option.Listen(IPAddress.Parse("127.0.0.1"), 8001, listenOption =>
                         {
                             listenOption.Protocols = HttpProtocols.Http1AndHttp2;
                         });
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
