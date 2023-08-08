using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class Comment : CommonEntity
{
    public string Text { get; set; }
    public int AnnouncementId { get; set; }
    public virtual Announcement Announcement { get; set; }
}