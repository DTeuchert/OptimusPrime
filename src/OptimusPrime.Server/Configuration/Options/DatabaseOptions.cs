using System.ComponentModel.DataAnnotations;

namespace OptimusPrime.Server.Configuration.Options
{
    public class DatabaseOptions
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}
