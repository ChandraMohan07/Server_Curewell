using System.Numerics;
using WebApi_Curewell.Models;

namespace WebApi_Curewell.DAL
{
    public class DoctorSpecializationHelper:IDoctorSpecializationHelper
    {
        private CurewellDbContext context;
        public DoctorSpecializationHelper(CurewellDbContext _context)
        {
            context = _context;
        }

        public List<Doctor> GetDoctorsBySpecialization(string specializationCode)
        {
            try
            {
                if (!context.DoctorSpecializations.Any(d => d.SpecializationCode == specializationCode))
                {
                    return null;
                }
                List<Doctor> dList = context.Doctors
                    .Where(doc => context.DoctorSpecializations.Any(ds => ds.SpecializationCode == specializationCode && ds.DoctorId == doc.DoctorId))
                    .ToList();

                return dList;
            }
            catch
            {
                return null;
            }
        }

        public bool AddSpecialization(DoctorSpecialization spec)
        {
            try
            {
                DoctorSpecialization doc = new DoctorSpecialization();
                doc.DoctorId = spec.DoctorId;
                doc.SpecializationCode = spec.SpecializationCode;
                doc.SpecializationDate = spec.SpecializationDate;
                context.DoctorSpecializations.Add(doc);
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