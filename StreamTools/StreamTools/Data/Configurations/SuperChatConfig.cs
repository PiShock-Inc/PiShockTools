using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamTools.Components.Models;

namespace StreamTools.Data.Configurations;

internal sealed class SuperChatConfig : IEntityTypeConfiguration<SuperChat>
{
    public void Configure(EntityTypeBuilder<SuperChat> builder)
    {
        builder.ToTable("Superchats");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasMany(x => x.Shockers).WithMany();
    }
}
