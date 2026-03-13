namespace OptimusPrime.Infrastructure.Persistence.Options;

public class DatabaseOptions
{
    public const string Database = "Database";
    
    public Provider Provider { get; set; } = Provider.Sqlite;

    /// <summary>
    /// If enabled, the database will be updated at app startup by running
    /// Entity Framework migrations. This is not recommended in production.
    /// </summary>
    public bool RunMigrationsAtStartup { get; set; } = true;
}

public record Provider(string Name) 
{
    public static readonly Provider Sqlite = new (nameof(Sqlite));
}
