using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
using Serilog;
using StreamTools.Components.Models;
namespace StreamTools.Data;

internal sealed class StreamToolsContext : DbContext {
    public DbSet<Cheer> Cheers { get; set; }
    public DbSet<Redeem> Redeems { get; set; }
    public DbSet<Shocker> Shockers { get; set; }
    public DbSet<SuperChat> SuperChats { get; set; }

    public StreamToolsContext() { 
    }
   
    public StreamToolsContext(DbContextOptions<StreamToolsContext> options) : base(options)
    {
        SQLitePCL.Batteries_V2.Init();
        Log.Debug(Database.GetConnectionString());
        Database.GetAppliedMigrations();
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StreamToolsContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), SqlLiteConstants.DatabasePath);
        Log.Debug("DB Path is " + dbPath);
        optionsBuilder.UseSqlite($"Data Source={dbPath}")
#if DEBUG
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
#endif
            .EnableServiceProviderCaching();

        base.OnConfiguring(optionsBuilder);
    }
}