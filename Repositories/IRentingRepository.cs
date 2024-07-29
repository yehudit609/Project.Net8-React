using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRentingRepository
    {
        Task<Renting> AddRenting(Renting renting);
        Task<List<Renting>> GetRentings();
        Task<Renting> GetRentingById(int id);
    }
}
