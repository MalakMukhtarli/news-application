using MediatR;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Admin.Announcements.Queries;

public class GetSingleAnnouncementForAdminQuery : IRequest<Announcement>
{
    public int Id { get; set; }
    
    public class GetSingleAnnouncementForAdminQueryHandler : IRequestHandler<GetSingleAnnouncementForAdminQuery, Announcement>
    {
        protected readonly IAnnouncementRepository _announcementRepository;

        public GetSingleAnnouncementForAdminQueryHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<Announcement> Handle(GetSingleAnnouncementForAdminQuery request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetByIdAsync(request.Id);

            return announcement;
        }
    }

}