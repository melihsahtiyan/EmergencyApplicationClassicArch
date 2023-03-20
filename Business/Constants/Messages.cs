using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserNotFound = "User not found";
        public static string UserRegistered = "User registered!";
        public static string PasswordError = "Password error!";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access token created!";
        public static string WrongEmailOrPassword = "Wrong email or password";

        public static string CategoryAdded = "Category added";
        public static string CategoryDeleted = "Category deleted";
        public static string CategoryUpdated = "Category updated";
        public static string CategoriesListed = "Category listed";

        public static string MedicationAdded = "Medication added";
        public static string MedicationDeleted = "Medication deleted";
        public static string MedicationUpdated = "Medication updated";
        public static string MedicationsListed = "Medication listed";

        public static string SystemStaffAdded = "System Staff added";
        public static string SystemStaffDeleted = "System Staff deleted";
        public static string SystemStaffUpdated = "System Staff updated";
        public static string SystemStaffsListed = "System Staff listed";

        public static string UserMedicationsAdded = "User medications added";
        public static string UserMedicationsDeleted = "User medications deleted";
        public static string UserMedicationsUpdated = "User medications Updated";
        public static string UserMedicationsListed = "User medications listed";

        public static string UserAdded = "User added";
        public static string UserDeleted = "User deleted";
        public static string UserUpdated = "User updated";
        public static string UsersListed = "User listed";

        public static string AllergyAdded = "Allergy added";
        public static string AllergyDeleted = "Allergy deleted";
        public static string AllergyUpdated = "Allergy updated";
        public static string AllergiesListed = "Allergy listed";

        public static string AuthorizationDenied = "Authorization denied!";

        public static string ContactListed = "Contact listed";
        public static string ContactExists = "Contact exists";
        public static string ContactAdded = "Contact added";
        public static string ContactNotExists = "Contact not exists";
        public static string ContactDeleted = "Contact deleted";
        
        public static string MedicalHistoriesListed = "Medical histories listed";
        public static string MedicalHistoryListed = "Medical history listed";
        public static string MedicalHistoryNotFound = "Medical history not found";
        public static string MedicalHistoryAdded = "Medical history added";
        public static string MedicalHistoryExists = "Medical history exists";
        public static string MedicalHistoryDeleted = "Medical history deleted";
        public static string MedicalHistoryUpdated = "Medical history updated";
        
    }
}
