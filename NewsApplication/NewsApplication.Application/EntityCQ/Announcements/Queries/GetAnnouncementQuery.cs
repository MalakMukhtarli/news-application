using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Application.ViewModels.Announcements;
using NewsApplication.Core.Repositories.Special;

namespace NewsApplication.Application.EntityCQ.Announcements.Queries;

public class GetAnnouncementQuery : IRequest<List<AnnouncementViewModel>?>
{
    public class GetAnnouncementQueryHandler : IRequestHandler<GetAnnouncementQuery, List<AnnouncementViewModel>?>
    {
        protected readonly IAnnouncementRepository _announcementRepository;
        protected readonly IMapper _mapper;

        public GetAnnouncementQueryHandler(IAnnouncementRepository announcementRepository, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
        }

        public async Task<List<AnnouncementViewModel>?> Handle(GetAnnouncementQuery request, CancellationToken cancellationToken)
        {
            var announcements = await _announcementRepository.GetQuery()
                .Include(x=>x.Likes)
                .Select(x => new AnnouncementViewModel
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