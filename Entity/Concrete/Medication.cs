
namespace Entity.Concrete;

public class Medication:Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<UserMedications> UserMedications { get; set; }

    public Medication()
    {
    }

    public Medication(int id, string name, string description) : base()
    {
        Id = id;
        Name = name;
        Description = description;
    }
}