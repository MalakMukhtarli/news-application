using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;
using File = NewsApplication.Models.Entities.File;

namespace NewsApplication.Application.EntityCQ.Admin.Announcements.Commands;

public class AnnouncementPostCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<IFormFile> Files { get; set; }

    public class AnnouncementPostCommandHandler : IRequestHandler<AnnouncementPostCommand, int>
    {
        protected readonly IAnnouncementRepository _announcementRepository;
        readonly IHostEnvironment _env;
        
        public AnnouncementPostCommandHandler(IAnnouncementRepository announcementRepository, IHostEnvironment env)
        {
            _announcementRepository = announcementRepository;
            _env = env;
        }

        public async Task<int> Handle(AnnouncementPostCommand request, CancellationToken cancellationToken)
        {
            var announcementFiles = new List<AnnouncementFile>();
            
            foreach (var file in request.Files)
            {
                var newFile = new File();
                var extension = Path.GetExtension(file.FileName);
                newFile.Name = $"{Guid.NewGuid()}{extension}";
            
                var physicalAddress = Path.Combine(_env.ContentRootPath,
                    "wwwroot",
                    "images",
                    "announcements",
                    newFile.Name);

                await using (var stream = new FileStream(physicalAddress, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(stream, cancellationToken);
                }
                
                announcementFiles.Add(new AnnouncementFile { File = newFile });
            }

            var announcement = new Announcement
            {
                Title = request.Title, 
                Description = request.Description,
                AnnouncementFiles = announcementFiles
            };
            
            var entity = await _announcementRepository.AddAsync(announcement, cancellationToken);
            return entity.Id;
        }
    }
}