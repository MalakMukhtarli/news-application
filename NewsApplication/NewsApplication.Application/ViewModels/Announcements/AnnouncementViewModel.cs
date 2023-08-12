using NewsApplication.Application.Mappings;
using NewsApplication.Application.ViewModels.Files;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.ViewModels.Announcements;

public class AnnouncementViewModel : IMapFrom<Announcement>
{
    public int Id { get; set; }
    public string Title { get; set; }
    // public int LikeCount { get; set; }
    // public int DislikeCount { get; set; }
    // public List<FileViewModel> Files { get; set; }
}