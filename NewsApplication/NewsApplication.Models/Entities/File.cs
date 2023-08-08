using System.Data;
using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class File : BaseEntity
{
    public File()
    {
        AnnouncementFiles = new HashSet<AnnouncementFile>();
    }
    
    public string Name { get; set; }
    
    public virtual ICollection<AnnouncementFile> AnnouncementFiles { get; set; }
}