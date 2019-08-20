using System.ComponentModel.DataAnnotations;

namespace OptimusPrime.Server.Configuration.Options
{
    public class OptimusPrimeOptions
    {
        /// <summary>
        /// If enabled, the database will be updated at app startup by running
        /// Entity Framework migrations. This is not recommended in production.
        /// </summary>
        public bool RunMigrationsAtStartup { get; set; } = true;

        [Required]
        public DatabaseOptions Database { get; set; }
    }
}
