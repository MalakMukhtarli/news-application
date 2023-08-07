using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class Comment : CommonEntity
{
    public string Text { get; set; }
    public int NewsId { get; set; }
    public virtual News News { get; set; }
}