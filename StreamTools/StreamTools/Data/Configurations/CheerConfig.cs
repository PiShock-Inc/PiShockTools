using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamTools.Components.Models;

namespace StreamTools.Data.Configurations;

internal sealed class CheerConfig : IEntityTypeConfiguration<Cheer>
{
    public void Configure(EntityTypeBuilder<Cheer> builder)
    {
        builder.ToTable("Cheers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}
