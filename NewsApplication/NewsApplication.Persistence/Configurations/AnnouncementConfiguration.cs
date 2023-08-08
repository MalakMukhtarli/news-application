using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApplication.Models.Entities;

namespace NewsApplication.Persistence.Configurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.Property(p => p.Id).HasColumnType("integer");
        builder.Property(p => p.Title).HasColumnType("nvarchar").HasMaxLength(400).IsRequired();
        builder.Property(p => p.Description).HasColumnType("nvarchar").HasMaxLength(1000).IsRequired();
        
        builder.HasKey(x => x.Id);
        builder.ToTable("Announcements");
    }
}