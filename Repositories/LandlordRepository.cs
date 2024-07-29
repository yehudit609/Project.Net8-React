
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class LandlordRepository : ILandlordRepository
    {
        private CarRetalContext _picturesStoreContext;

        public LandlordRepository(CarRetalContext picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }

        public async Task<Landlord> AddLandlord(Landlord landlord)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Landlord>> GetLandlords()
        {
            var foundLandlords = await _picturesStoreContext.Landlords.ToListAsync();
            if (foundLandlords == null)
                return null;
            return foundLandlords;
        }

        public async Task<Landlord> GetLandlordById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Landlord> UpdateLandlord(int id, Landlord landlordToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
