using NewsApplication.Application.Mappings;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Comments.ViewModels;

public class CommentViewModel : IMapFrom<Comment>
{
    public string Text { get; set; }
    public string? UserName { get; set; }
    public string? UserSurname { get; set; }
}