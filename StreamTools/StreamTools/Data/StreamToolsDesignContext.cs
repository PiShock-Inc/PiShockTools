using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StreamTools.Data;

internal class StreamToolsDesignContext : IDesignTimeDbContextFactory<StreamToolsContext>
{
    public StreamToolsDesignContext()
    {

    }
    public StreamToolsContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<StreamToolsContext>()
            .UseSqlite()
            .EnableDetailedErrors()
            .EnableServiceProviderCaching()
            .Options;
        return new StreamToolsContext(options);
    }
}