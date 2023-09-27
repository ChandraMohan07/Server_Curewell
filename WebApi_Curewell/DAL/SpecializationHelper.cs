using WebApi_Curewell.Models;

namespace WebApi_Curewell.DAL
{
    public class SpecializationHelper : ISpecializationHelper
    {
        private CurewellDbContext context;
        public SpecializationHelper(CurewellDbContext _context)
        {
            context = _context;
        }
        public List<Specialization> GetAllSpecializations()
        {
            try
            {
                List<Specialization> docList = new List<Specialization>();
                foreach (Specialization spec in context.Specializations)
                {
                    docList.Add(spec);
                }
                return docList;
            }
            catch
            {
                return null;
            }
        }

        public bool AddSpecialization(Specialization spec)
        {
            try
            {
                Specialization specialzation = new Specialization();
                specialzation.SpecializationCode = spec.SpecializationCode;
                specialzation.SpecializationName = spec.SpecializationName;
                context.Specializations.Add(specialzation);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
