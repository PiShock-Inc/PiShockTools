using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
namespace StreamTools.Data;

internal sealed class StreamToolsContext : DbContext
{
    public StreamToolsContext(DbContextOptions<StreamToolsContext> options) : base(options)
    {
        SQLitePCL.Batteries_V2.Init();
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StreamToolsContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, SqlLiteConstants.DatabasePath);
        optionsBuilder.UseSqlite($"Data Source={dbPath}")
#if DEBUG
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
#endif
            .EnableServiceProviderCaching();

        base.OnConfiguring(optionsBuilder);
    }
}