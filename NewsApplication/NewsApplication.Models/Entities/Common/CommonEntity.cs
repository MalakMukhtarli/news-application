namespace NewsApplication.Models.Entities.Common;

public abstract class CommonEntity : BaseEntity, IActiveEntity,
    ISoftDeletedEntity, ICreatedDateEntity, IUpdatedDateEntity, ICreatedByEntity, IUpdatedByEntity
{
    public bool Active { get; set; } = true;
    public bool Deleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int? CreatedUserId { get; set; }
    public int? UpdatedUserId { get; set; }
}