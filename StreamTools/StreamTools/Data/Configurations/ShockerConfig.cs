using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamTools.Components.Models;

namespace StreamTools.Data.Configurations;
internal sealed class ShockerConfig : IEntityTypeConfiguration<Shocker>
{
    public void Configure(EntityTypeBuilder<Shocker> builder)
    {
        builder.ToTable("Shockers");
        builder.HasKey(x => x.Code);
        builder.Property(x => x.Code).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Name).IsRequired();
    }
}