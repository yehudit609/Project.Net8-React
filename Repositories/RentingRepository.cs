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
        private CarRetalContext _CarRetalContext;

        public RentingRepository(CarRetalContext carRetalContext)
        {
            _CarRetalContext = carRetalContext;
        }

        public async Task<Renting> AddRenting(Renting renting)
        {
            try
            {
                await _CarRetalContext.Rentings.AddAsync(renting);
                await _CarRetalContext.SaveChangesAsync();
                return renting;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding renting: " + ex.Message);
            }
        }

        public async Task<List<Renting>> GetRentings()
        {
            try
            {
                var foundRentings = await _CarRetalContext.Rentings.ToListAsync();
                return foundRentings;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting rentings: " + ex.Message);
            }
        }

        public async Task<Renting> GetRentingById(int id)
        {
            try
            {
                var foundRenting = await _CarRetalContext.Rentings.FirstOrDefaultAsync(r => r.RentingId == id);
                return foundRenting;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting renting by ID: " + ex.Message);
            }
        }
    }
}
