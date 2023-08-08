using MediatR;
using NewsApplication.Core.Repositories.Special;

namespace NewsApplication.Application.EntityCQ.Announcements.Commands;

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

            return 1;
        }
    }
}