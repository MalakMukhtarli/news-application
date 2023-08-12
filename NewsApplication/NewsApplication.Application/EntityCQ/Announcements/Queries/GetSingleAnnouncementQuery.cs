using MediatR;
using NewsApplication.Application.ViewModels;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Announcements.Queries;

public class GetSingleAnnouncementQuery : IRequest<Announcement>
{
    public int Id { get; set; }
    
    public class GetSingleAnnouncementQueryHandler : IRequestHandler<GetSingleAnnouncementQuery, Announcement>
    {
        protected readonly IAnnouncementRepository _announcementRepository;

        public GetSingleAnnouncementQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<Announcement> Handle(GetSingleAnnouncementQuery request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetByIdAsync(request.Id);

            return announcement;
        }
    }

}