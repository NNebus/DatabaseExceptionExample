using Microsoft.EntityFrameworkCore;
using Shared.Models.Services;
using Shared.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
     
        public string _databasePath;
        private IDependencyService _dependencyService;
        private ConfigurationHelper _configurationHelper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="databasePath">Name / Path the database should be saved at.</param>
        public DatabaseContext() : this(new DependencyServiceWrapper())
        {
        }

        public DatabaseContext(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
            _configurationHelper = _dependencyService.Get<ConfigurationHelper>();
            _databasePath = _configurationHelper.DatabasePath;

            try{
                #region if we use one or more of the following methods, the application stops running on a hardwaredevice
                // in case we want to delete the DB
                if (false)
                {
                   // Database.EnsureDeleted();
                }

                //Create and Migrate DB if necessary
                //Database.EnsureCreated();
                //Database.MigrateAsync();
                #endregion if we use one or more of the following methods, the application stops running on a hardwaredevice
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        /// <summary>
        /// Called automatically. Configures Sqlite
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var a = "this line will be executed but not the line after!";
            try
            {
                optionsBuilder.UseSqlite($"Filename={_databasePath}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }
}
