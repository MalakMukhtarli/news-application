using NewsApplication.Application.EntityCQ.Comments.ViewModels;
using NewsApplication.Application.EntityCQ.Files.ViewModels;
using NewsApplication.Application.Mappings;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Admin.Announcements.ViewModels;

public class AnnouncementDetailForAdminViewModel : IMapFrom<Announcement>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int LikeCount { get; set; }
    public int DislikeCount { get; set; }
    public List<CommentViewModel>? Comments { get; set; }
    public List<FileViewModel>? Files { get; set; }
}