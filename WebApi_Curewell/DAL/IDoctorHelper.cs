using WebApi_Curewell.Models;

namespace WebApi_Curewell.DAL
{
    public interface IDoctorHelper
    {
        public bool AddDoctor(Doctor doctor);
        public List<Doctor> GetAllDoctors();
        public bool DeleteDoctor(int id);
        public bool UpdateDoctorDetails(Doctor doctor);
    }
}
