using WebApi_Curewell.Models;

namespace WebApi_Curewell.DAL
{
    public interface IDoctorHelper
    {
        public bool AddDoctor(Doctor doctor);
        public List<Doctor> GetAllDoctors();
        public bool DeleteDoctor(Doctor doctor);
        public bool UpdateDoctorDetails(Doctor doctor);
    }
}
