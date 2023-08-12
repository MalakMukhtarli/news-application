using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApplication.Models.Entities;

namespace NewsApplication.Persistence.Configurations;

public class AnnouncementFileConfiguration : IEntityTypeConfiguration<AnnouncementFile>
{
    public void Configure(EntityTypeBuilder<AnnouncementFile> builder)
    {
        builder.Property(p => p.Id).HasColumnType("integer");
        builder.Property(p => p.AnnouncementId).HasColumnType("integer");
        builder.Property(p => p.FileId).HasColumnType("integer");
        
        builder.HasKey(x => x.Id);
        builder.ToTable("AnnouncementFiles");
    }
}