namespace NewsApplication.Models.Entities.Common;

public interface IUpdatedByEntity
{
    int? UpdatedUserId { get; set; }
}