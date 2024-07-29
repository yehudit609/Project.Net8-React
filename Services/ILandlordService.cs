using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ILandlordService
    {
        Task<Landlord> AddLandlord(Landlord landlord);
        Task<List<Landlord>> GetLandlords();
        Task<Landlord> GetLandlordById(Landlord landlord);
    }
}
