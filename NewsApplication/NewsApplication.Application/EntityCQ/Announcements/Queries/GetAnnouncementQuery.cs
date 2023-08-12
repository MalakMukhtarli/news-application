using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Application.ViewModels.Announcements;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Announcements.Queries;

public class GetAnnouncementQuery : IRequest<List<Announcement>?>
{
    public class GetAnnouncementQueryHandler : IRequestHandler<GetAnnouncementQuery, List<Announcement>?>
    {
        protected readonly IAnnouncementRepository _announcementRepository;
        protected readonly IMapper _mapper;

        public GetAnnouncementQueryHandler(IAnnouncementRepository announcementRepository, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
        }

        public async Task<List<Announcement>?> Handle(GetAnnouncementQuery request, CancellationToken cancellationToken)
        {
            var announcements = await _announcementRepository.GetQuery()
                .Include(x=>x.Likes)
                .ToListAsync(cancellationToken: cancellationToken);

            // var announcementViewModels = _mapper.Map<AnnouncementViewModel?>(announcements.FirstOrDefault());

            return announcements;
        }
    }
}