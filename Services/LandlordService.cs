using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class LandlordService : ILandlordService
    {
        private readonly ILandlordRepository _landlordRepository;

        public LandlordService(ILandlordRepository landlordRepository)
        {
            _landlordRepository = landlordRepository;
        }

        public async Task<Landlord> AddLandlord(Landlord landlord)
        {
            // Implement the logic to add a new landlord using the repository
            return await _landlordRepository.AddLandlord(landlord);
        }

        public async Task<List<Landlord>> GetLandlords()
        {
            // Implement the logic to get all landlords using the repository
            return await _landlordRepository.GetLandlords();
        }

        public async Task<Landlord> GetLandlordById(int id)
        {
            // Implement the logic to get a landlord by ID using the repository
            return await _landlordRepository.GetLandlordById(id);
        }

        public async Task<Landlord> UpdateLandlord(int id, Landlord landlordToUpdate)
        {
            // Implement the logic to update a landlord using the repository
            return await _landlordRepository.UpdateLandlord(id, landlordToUpdate);
        }
    }
}
