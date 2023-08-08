using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace NewsApplication.Persistence.Context;

public class NewsAppDbContext : DbContext
{
    public NewsAppDbContext(DbContextOptions<NewsAppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     base.OnConfiguring(optionsBuilder);
    //     optionsBuilder.UseSqlServer("data source=RHD-PROG-16\\SQLEXPRESS;Initial Catalog=NewsApplication;TrustServerCertificate=True;Integrated Security=sspi");
    // }
}