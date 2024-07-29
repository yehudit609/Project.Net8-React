using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class RentingRepository : IRentingRepository
    {
        private CarRetalContext _picturesStoreContext;

        public RentingRepository(CarRetalContext picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }

        public async Task<Renting> AddRenting(Renting renting)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Renting>> GetRentings()
        {
            var foundRentings = await _picturesStoreContext.Rentings.ToListAsync();
            if (foundRentings == null)
                return null;
            return foundRentings;
        }

        public async Task<Renting> GetRentingById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Renting> UpdateRenting(int id, Renting rentingToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
