using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo.Service
{
    public class ConfigurationService
    {
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;

        public string DatabaseConnectionString { get; set; }


        public ConfigurationService(IConfiguration configuration)
        {
            Configuration = configuration;
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            DatabaseConnectionString = Configuration["DATABASE_CONNECTION"];
        }
    }
}
