using MediatR;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Admin.Announcements.Commands;

public class AnnouncementPostCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }

    public class AnnouncementPostCommandHandler : IRequestHandler<AnnouncementPostCommand, int>
    {
        protected readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementPostCommandHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<int> Handle(AnnouncementPostCommand request, CancellationToken cancellationToken)
        {

            var announcement = new Announcement { Title = request.Title, Description = request.Description };

            var entity = await _announcementRepository.AddAsync(announcement, cancellationToken);
            return entity.Id;
        }
    }
}