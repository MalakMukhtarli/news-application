namespace NewsApplication.Models.Entities.Common;

public interface ISoftDeletedEntity
{
    bool Deleted { get; set; }
}