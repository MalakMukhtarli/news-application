using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class Announcement : CommonEntity
{
    public Announcement()
    {
        AnnouncementFiles = new HashSet<AnnouncementFile>();
        Likes = new HashSet<Like>();
        Comments = new HashSet<Comment>();
    }
    
    public string Title { get; set; }
    public string Description { get; set; }
    
    public virtual ICollection<AnnouncementFile> AnnouncementFiles { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }

}