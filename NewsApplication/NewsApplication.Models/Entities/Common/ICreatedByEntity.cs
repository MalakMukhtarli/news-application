namespace NewsApplication.Models.Entities.Common;

public interface ICreatedByEntity
{
    int? CreatedUserId { get; set; }
}