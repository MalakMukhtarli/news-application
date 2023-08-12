using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsApplication.Models.Entities;

namespace NewsApplication.Persistence.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(p => p.Id).HasColumnType("integer");
        builder.Property(p => p.Text).HasColumnType("nvarchar").IsRequired();
        builder.Property(p => p.AnnouncementId).HasColumnType("integer");
        
        builder.HasKey(x => x.Id);
        builder.ToTable("Comments");
    }
}