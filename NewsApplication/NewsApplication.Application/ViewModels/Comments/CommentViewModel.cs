using NewsApplication.Application.Mappings;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.ViewModels.Comments;

public class CommentViewModel : IMapFrom<Comment>
{
    public string Text { get; set; }
    public User? User { get; set; }
}