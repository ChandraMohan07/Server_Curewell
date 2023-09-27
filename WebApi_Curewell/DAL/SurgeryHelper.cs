using System.Numerics;
using WebApi_Curewell.Models;

namespace WebApi_Curewell.DAL
{
    public class SurgeryHelper:ISurgeryHelper
    {
        private CurewellDbContext context;
        public SurgeryHelper(CurewellDbContext _context)
        {
            context = _context;
        }

        public bool AddSurgery(Surgery surgery)
        {
            try
            {
                Surgery sur = new Surgery();
                sur.DoctorId = surgery.DoctorId;
                sur.SurgeryDate = surgery.SurgeryDate;
                sur.StartTime = surgery.StartTime;
                sur.EndTime = surgery.EndTime;
                sur.SurgeryCategory = surgery.SurgeryCategory;
                context.Surgeries.Add(sur);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Surgery> GetAllSurgeryTypeForToday()
        {
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            try
            {
                List<Surgery> surList = new List<Surgery>();
                foreach (Surgery sur in context.Surgeries)
                {
                    string surDate = sur.SurgeryDate.ToString("yyyy-MM-dd");
                    if (surDate == date)
                    {
                        surList.Add(sur);
                    }
                }
                return surList;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateSurgery(Surgery surgery)
        {
            try
            {
                Surgery sur = context.Surgeries.SingleOrDefault(s => s.SurgeryId == surgery.SurgeryId);
                sur.DoctorId = surgery.DoctorId;
                sur.SurgeryDate = surgery.SurgeryDate;
                sur.StartTime = surgery.StartTime;
                sur.EndTime = surgery.EndTime;
                sur.SurgeryCategory = surgery.SurgeryCategory;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSurgery(int id)
        {
            try
            {
                Surgery s = context.Surgeries.SingleOrDefault(s => s.SurgeryId == id);
                context.Surgeries.Remove(s);
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
