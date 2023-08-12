namespace NewsApplication.Application.ViewModels.Admin.Announcements.ViewModels;

public class AnnouncementForAdminViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int LikeCount { get; set; }
    public int DislikeCount { get; set; }
}