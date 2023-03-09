using Entity.Abstract;
using Entity.Concrete;

namespace Entity.Concrete;

public class UserOperationClaim : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
    }

    public UserOperationClaim(int id, int userId, int operationClaimId) : base()
    {
        Id = id;
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}