using Microsoft.AspNetCore.Mvc;
using WebApi_Curewell.Models;

namespace WebApi_Curewell.DAL
{
    public class DoctorHelper : IDoctorHelper
    {
        private CurewellDbContext context;
        public DoctorHelper(CurewellDbContext _context)
        {
            context = _context;
        }
        public bool AddDoctor(Doctor doctor)
        {
            try
            {
                Doctor doc = new Doctor();
                doc.DoctorName = doctor.DoctorName;
                context.Doctors.Add(doc);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //delete doctor
        public bool DeleteDoctor(int id)
        {
            try
            {
                Doctor doc = context.Doctors.SingleOrDefault(d => d.DoctorId == id);
                context.Doctors.Remove(doc);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            try
            {
                List<Doctor> docList = new List<Doctor>();
                docList = context.Doctors.ToList();
                if (docList != null) return docList;
                else return null;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateDoctorDetails(Doctor doctor)
        {
            try
            {
                Doctor doc = context.Doctors.SingleOrDefault(d => d.DoctorId == doctor.DoctorId);
                doc.DoctorName = doctor.DoctorName;
                context.Doctors.Update(doc);
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
