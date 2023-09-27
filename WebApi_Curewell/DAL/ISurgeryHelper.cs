using WebApi_Curewell.Models;

namespace WebApi_Curewell.DAL
{
    public interface ISurgeryHelper
    {
        public List<Surgery> GetAllSurgeryTypeForToday();
        public bool UpdateSurgery(Surgery surgery);
        public bool AddSurgery(Surgery surgery);
    }
}
