using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Application.EntityCQ.Admin.Announcements.ViewModels;
using NewsApplication.Application.EntityCQ.Comments.ViewModels;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Admin.Announcements.Queries;

public class GetSingleAnnouncementForAdminQuery : IRequest<AnnouncementDetailForAdminViewModel>
{
    public int Id { get; set; }
    
    public class GetSingleAnnouncementForAdminQueryHandler : IRequestHandler<GetSingleAnnouncementForAdminQuery, AnnouncementDetailForAdminViewModel>
    {
        protected readonly IAnnouncementRepository _announcementRepository;

        public GetSingleAnnouncementForAdminQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<AnnouncementDetailForAdminViewModel> Handle(GetSingleAnnouncementForAdminQuery request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetQuery()
                    .Include(x => x.Likes)
                    .Include(x => x.Comments)
                    .Include(x => x.AnnouncementFiles)
                    .ThenInclude(y => y.File)
                    .Where(x=>x.Id == request.Id && x.Active && !x.Deleted)
                    .Select(x => new AnnouncementDetailForAdminViewModel
                    {
                        Title = x.Title,
                        Description = x.Description,
                        LikeCount = x.Likes.Count(y => y.IsLike),
                        DislikeCount = x.Likes.Count(y => !y.IsLike),
                        Comments = x.Comments.Select(y=> new CommentViewModel{ Text = y.Text}).ToList()
                    })
                    .FirstOrDefaultAsync(cancellationToken)
                ;

            return announcement;
        }
    }

}