using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration.Json;

namespace SZP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void Initialize()
        {
            var connectionString = Configuration.GetConnectionString("SZPConnectionString");
            var paymentManager = new PaymentManager(connectionString);

            
        }
    }
}
