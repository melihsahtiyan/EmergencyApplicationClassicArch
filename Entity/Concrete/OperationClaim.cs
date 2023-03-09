using Entity.Abstract;

namespace Entity.Concrete;

public class OperationClaim : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(int id, string name) : base()
    {
        Id = id;
        Name = name;
    }
}