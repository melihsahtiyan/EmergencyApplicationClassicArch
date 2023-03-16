
namespace Entity.Concrete;

public class MedicalHistory : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<UserMedicalHistories> UserMedicalHistories { get; set; }

    public MedicalHistory()
    {
    }

    public MedicalHistory(int id, string name, string description) : base()
    {
        Id = id;
        Name = name;
        Description = description;
    }
}