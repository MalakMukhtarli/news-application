using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Models.Entities;

namespace NewsApplication.Persistence.Context;

public class NewsAppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public NewsAppDbContext(DbContextOptions<NewsAppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

}