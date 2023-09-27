using WebApi_Curewell.Models;

namespace WebApi_Curewell.DAL
{
    public interface IDoctorSpecializationHelper
    {
        public List<Doctor> GetDoctorsBySpecialization(string specializationCode);

        public bool AddSpecialization(DoctorSpecialization spec);
    }
}
