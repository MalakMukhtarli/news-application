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

        builder.HasOne<Announcement>()
            .WithMany()
            .HasForeignKey(f => f.AnnouncementId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Models.Entities.File>()
            .WithMany()
            .HasForeignKey(f => f.FileId).OnDelete(DeleteBehavior.NoAction);
    }
}