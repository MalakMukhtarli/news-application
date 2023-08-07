using System.Data;
using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class File : BaseEntity
{
    public File()
    {
        NewsFiles = new HashSet<NewsFile>();
    }
    
    public string Name { get; set; }
    
    public virtual ICollection<NewsFile> NewsFiles { get; set; }
}