using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Core.Repositories;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;

namespace NewsApplication.Persistence.Repositories.Concrete;

public class AnnouncementRepository : RepositoryBase<Announcement>, IAnnouncementRepository
{
    public AnnouncementRepository(IdentityDbContext<User, IdentityRole<int>, int> databaseContext) : base(databaseContext)
    {
    }
}