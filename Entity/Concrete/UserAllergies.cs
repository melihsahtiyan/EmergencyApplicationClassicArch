
namespace Entity.Concrete;

public class UserAllergies : Entity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int AllergyId { get; set; }
    public virtual Allergy Allergy { get; set; }

    public UserAllergies()
    {
    }

    public UserAllergies(int userId, int allergyId) : base()
    {
        UserId = userId;
        AllergyId = allergyId;
    }
}