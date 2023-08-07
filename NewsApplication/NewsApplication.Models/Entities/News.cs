using NewsApplication.Models.Entities.Common;

namespace NewsApplication.Models.Entities;

public class News : CommonEntity
{
    public News()
    {
        NewsFiles = new HashSet<NewsFile>();
        Likes = new HashSet<Like>();
        Comments = new HashSet<Comment>();
    }
    
    public string Title { get; set; }
    public string Description { get; set; }
    
    public virtual ICollection<NewsFile> NewsFiles { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }

}