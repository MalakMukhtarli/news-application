using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class Like : CommonEntity
{
    public bool IsLike { get; set; }
    public int NewsId { get; set; }
    public virtual News News { get; set; }
}