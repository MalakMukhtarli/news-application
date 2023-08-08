using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class Like : CommonEntity
{
    public bool IsLike { get; set; }
    public int AnnouncementId { get; set; }
    public virtual Announcement Announcement { get; set; }
}