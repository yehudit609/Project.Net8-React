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
        private
            CarRetalContext _picturesStoreContext;

        public LandlordRepository(CarRetalContext picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }

        public async Task<Landlord> AddLandlord(Landlord landlord)
        {
            try
            {
                await _picturesStoreContext.Landlords.AddAsync(landlord);
                await _picturesStoreContext.SaveChangesAsync();
                return landlord;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding landlord: " + ex.Message);
            }
        }

        public async Task<List<Landlord>> GetLandlords()
        {
            try
            {
                var foundLandlords = await _picturesStoreContext.Landlords.ToListAsync();
                return foundLandlords;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting landlords: " + ex.Message);
            }
        }

        public async Task<Landlord> GetLandlordById(Landlord landlord)
        {
            try
            {
                return await _picturesStoreContext.Landlords.Where(e => e.Email == landlord.Email && e.LandlordTz == landlord.LandlordTz).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting landlord by ID: " + ex.Message);
            }
        }
    }
}
