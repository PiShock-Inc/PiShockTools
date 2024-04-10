using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamTools.Components.Models;

namespace StreamTools.Data.Configurations;

internal sealed class RedeemConfig : IEntityTypeConfiguration<Redeem>
{
    public void Configure(EntityTypeBuilder<Redeem> builder)
    {
        builder.ToTable("Redeems");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);
        builder.HasMany(x => x.Shockers).WithMany();
    }
}
