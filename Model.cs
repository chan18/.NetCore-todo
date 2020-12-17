using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using todo.Service;

namespace todo
{
    public class Model : DbContext
    {

        private readonly IOptions<Settings> _settings;

        private ConfigurationService _configuration;

        public Model(IOptions<Settings> settings)
        {
            _settings = settings;
        }

        public DbSet<Todo> Todos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_settings.Value.DatabaseConfiguration);
    }

    public class Todo
    {
        public Guid Id {get; set;}
        public string Task {get; set;}
        public bool Completed {get; set;}
    }
}
