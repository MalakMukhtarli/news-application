using NewsApplication.Application.Mappings;
using NewsApplication.Application.ViewModels.Comments;
using NewsApplication.Application.ViewModels.Files;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.ViewModels.Announcements;

public class AnnouncementDetailViewModel : IMapFrom<Announcement>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int LikeCount { get; set; }
    public int DislikeCount { get; set; }
    public List<CommentViewModel> Comments { get; set; }
    public List<FileViewModel> Files { get; set; }
}