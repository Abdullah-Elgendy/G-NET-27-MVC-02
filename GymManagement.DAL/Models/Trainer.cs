using GymManagement.DAL.Models.Enums;

namespace GymManagement.DAL.Models
{
    public class Trainer : GymUser
    {
        public Speciality Speciality { get; set; }
        //change CreatedAt column name to HireDate
    }
}
