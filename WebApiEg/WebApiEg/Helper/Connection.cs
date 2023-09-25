using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace WebApiEg.Helper
{
    public class Connection
    {
        private IConfigurationRoot Configuration { get; set; }    
        public string GetConectionString()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration=configuration.Build();
            string conStr = Configuration.GetConnectionString("DefaultConnection");
            return conStr;
        }
    }
}
