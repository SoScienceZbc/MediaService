using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoScienceMediaService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        #region ServiceSetup
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time} just before Creating MediaService", DateTimeOffset.Now);

            string cert = "/home/soscience/Desktop/Services/soscience.dk.pfx";
            string pass = File.ReadAllText("/home/soscience/Desktop/Services/PassPhrase.txt");

            await Host.CreateDefaultBuilder().ConfigureWebHostDefaults(cw =>
            {
                cw.UseKestrel().UseStartup<Startup>().ConfigureKestrel(kj =>
                {
                    kj.Limits.MaxRequestBodySize = null; //unlimited. Not sure if good idea in the end
                    kj.Listen(System.Net.IPAddress.Any, 48048, lo =>
                    {
                        Console.WriteLine("use https");
                        lo.Protocols = HttpProtocols.Http2;
                        lo.UseHttps(cert, pass.Trim());
                    });
                });
            }).Build().StartAsync(stoppingToken);
        }
        #endregion
    }
}
