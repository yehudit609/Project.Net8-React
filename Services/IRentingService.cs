using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IRentingService
    {
        Task<Renting> AddRenting(Renting renting);
        Task<List<Renting>> GetRentings();
        Task<Renting> GetRentingById(int id);
    }
}
