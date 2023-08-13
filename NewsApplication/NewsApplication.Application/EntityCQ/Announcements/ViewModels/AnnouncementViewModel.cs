using NewsApplication.Application.EntityCQ.Files.ViewModels;
using NewsApplication.Application.Mappings;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Announcements.ViewModels;

public class AnnouncementViewModel : IMapFrom<Announcement>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int LikeCount { get; set; }
    public int DislikeCount { get; set; }
    public FileViewModel? File { get; set; }
}