namespace OptimusPrime.Infrastructure.Persistence.Options;
public class DatabaseOptions
{
    /// <summary>
    /// If enabled, the database will be updated at app startup by running
    /// Entity Framework migrations. This is not recommended in production.
    /// </summary>
    public bool RunMigrationsAtStartup { get; set; } = true;
    public string ConnectionString { get; set; }
}
