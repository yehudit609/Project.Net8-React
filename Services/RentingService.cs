using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class RentingService : IRentingService
    {
        private readonly IRentingRepository _rentingRepository;

        public RentingService(IRentingRepository rentingRepository)
        {
            _rentingRepository = rentingRepository;
        }

        public async Task<Renting> AddRenting(Renting renting)
        {
            // Implement the logic to add a new renting using the repository
            return await _rentingRepository.AddRenting(renting);
        }

        public async Task<List<Renting>> GetRentings()
        {
            // Implement the logic to get all rentings using the repository
            return await _rentingRepository.GetRentings();
        }

        public async Task<Renting> GetRentingById(int id)
        {
            // Implement the logic to get a renting by ID using the repository
            return await _rentingRepository.GetRentingById(id);
        }

    }
}
