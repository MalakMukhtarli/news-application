using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = NewsApplication.Models.Entities.File;

namespace NewsApplication.Persistence.Configurations;

public class FileConfiguration : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.Property(p => p.Id).HasColumnType("integer");
        builder.Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(100);
        
        builder.HasKey(x => x.Id);
        builder.ToTable("Files");
    }
}