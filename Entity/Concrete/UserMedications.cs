
namespace Entity.Concrete;


public class UserMedications : Entity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int MedicationId { get; set; }
    public virtual Medication Medication { get; set; }

    public UserMedications()
    {
    }

    public UserMedications(int userId, int medicationId) : base()
    {
        UserId = userId;
        MedicationId = medicationId;
    }
}