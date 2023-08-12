using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Application.EntityCQ.Announcements.ViewModels;
using NewsApplication.Application.ViewModels.Admin.Announcements.ViewModels;
using NewsApplication.Core.Repositories.Special;

namespace NewsApplication.Application.EntityCQ.Admin.Announcements.Queries;

public class GetAnnouncementForAdminQuery : IRequest<List<AnnouncementForAdminViewModel>?>
{
    public class GetAnnouncementForAdminQueryHandler : IRequestHandler<GetAnnouncementForAdminQuery, List<AnnouncementForAdminViewModel>?>
    {
        protected readonly IAnnouncementRepository _announcementRepository;

        public GetAnnouncementForAdminQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<List<AnnouncementForAdminViewModel>?> Handle(GetAnnouncementForAdminQuery request, CancellationToken cancellationToken)
        {
            var announcements = await _announcementRepository.GetQuery()
                .Include(x=>x.Likes)
                .Select(x => new AnnouncementForAdminViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    LikeCount = x.Likes.Count(y => y.IsLike),
                    DislikeCount = x.Likes.Count(y => !y.IsLike)
                })
                .ToListAsync(cancellationToken: cancellationToken);

            
            return announcements;
        }
    }
}