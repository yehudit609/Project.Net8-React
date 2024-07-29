using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ILandlordRepository
    {
        Task<Landlord> AddLandlord(Landlord landlord);
        Task<List<Landlord>> GetLandlords();
        Task<Landlord> GetLandlordById(Landlord landlord);
    }
}
