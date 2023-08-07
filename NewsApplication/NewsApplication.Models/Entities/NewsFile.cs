using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class NewsFile : BaseEntity
{
    public int NewsId { get; set; }
    public virtual News News { get; set; }
    public int FileId { get; set; }
    public virtual File File { get; set; }
}