using WebApi_Curewell.Models;

namespace WebApi_Curewell.DAL
{
    public interface ISpecializationHelper
    {
        public List<Specialization> GetAllSpecializations();

        public bool AddSpecialization(Specialization spec);
    }
}
