using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class AnnouncementFile : BaseEntity
{
    public int AnnouncementId { get; set; }
    public virtual Announcement Announcement { get; set; }
    public int FileId { get; set; }
    public virtual File File { get; set; }
}