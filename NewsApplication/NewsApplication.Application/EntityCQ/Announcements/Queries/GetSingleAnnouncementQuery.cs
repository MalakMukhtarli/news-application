using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Application.EntityCQ.Announcements.ViewModels;
using NewsApplication.Application.EntityCQ.Comments.ViewModels;
using NewsApplication.Application.EntityCQ.Files.ViewModels;
using NewsApplication.Core.Repositories.Special;

namespace NewsApplication.Application.EntityCQ.Announcements.Queries;

public class GetSingleAnnouncementQuery : IRequest<AnnouncementDetailViewModel>
{
    public int Id { get; set; }
    
    public class GetSingleAnnouncementQueryHandler : IRequestHandler<GetSingleAnnouncementQuery, AnnouncementDetailViewModel>
    {
        protected readonly IAnnouncementRepository _announcementRepository;

        public GetSingleAnnouncementQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<AnnouncementDetailViewModel> Handle(GetSingleAnnouncementQuery request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetQuery()
                    .Include(x => x.Likes)
                    .Include(x => x.Comments)
                    .Include(x => x.AnnouncementFiles)
                        .ThenInclude(y => y.File)
                    .Where(x=>x.Id == request.Id && x.Active && !x.Deleted)
                    .Select(x => new AnnouncementDetailViewModel
                    {
                        Title = x.Title,
                        Description = x.Description,
                        LikeCount = x.Likes.Count(y => y.IsLike),
                        DislikeCount = x.Likes.Count(y => !y.IsLike),
                        Comments = x.Comments.Select(y=> new CommentViewModel{ Text = y.Text}).ToList(),
                        Files = x.AnnouncementFiles.Select(y=> new FileViewModel{Name = y.File.Name}).ToList()
                    })
                    .FirstOrDefaultAsync(cancellationToken)
                ;
            
            

            return announcement;
        }
    }

}