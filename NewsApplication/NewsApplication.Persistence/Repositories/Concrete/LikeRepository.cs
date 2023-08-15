using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NewsApplication.Core.Repositories;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;

namespace NewsApplication.Persistence.Repositories.Concrete;

public class LikeRepository : RepositoryBase<Like>, ILikeRepository
{
    public LikeRepository(IdentityDbContext<User, IdentityRole<int>, int> databaseContext) : base(databaseContext)
    {
    }
}