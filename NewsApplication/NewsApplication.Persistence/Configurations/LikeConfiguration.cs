using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApplication.Models.Entities;

namespace NewsApplication.Persistence.Configurations;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.Property(p => p.Id).HasColumnType("integer");
        builder.Property(p => p.IsLike).HasColumnType("bit").IsRequired();
        builder.Property(p => p.AnnouncementId).HasColumnType("integer");
        
        builder.HasKey(x => x.Id);
        builder.ToTable("Likes");

        builder.HasOne<Announcement>()
            .WithMany()
            .HasForeignKey(f => f.AnnouncementId).OnDelete(DeleteBehavior.NoAction);
    }
}