namespace OptimusPrime.Api.Configurations.Options;

public class DatabaseOptions
{
    public const string Database = "Database";
    
    public Provider Provider { get; set; } = Provider.Sqlite;

    /// <summary>
    /// If enabled, the database will be updated at app startup by running
    /// Entity Framework migrations. This is not recommended in production.
    /// </summary>
    public bool RunMigrationsAtStartup { get; set; }
}

public record Provider(string Name, string Assembly) 
{
    public static readonly Provider Sqlite = new (nameof(Sqlite), typeof(Sqlite.Marker).Assembly.GetName().Name!);
}