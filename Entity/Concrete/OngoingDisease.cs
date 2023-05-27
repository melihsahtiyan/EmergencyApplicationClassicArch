
namespace Entity.Concrete;

public class OngoingDisease : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<UserOngoingDisease> UserOngoingDiseases { get; set; }

    public OngoingDisease()
    {
    }

    public OngoingDisease(int id, string name, string description) : base()
    {
        Id = id;
        Name = name;
        Description = description;
    }
}