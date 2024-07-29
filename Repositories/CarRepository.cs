
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class CarRepository : ICarRepository
    {
        private CarRetalContext _picturesStoreContext;

        public CarRepository(CarRetalContext picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }

        public async Task<Car> AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Car>> GetCars()
        {
            var foundCars = await _picturesStoreContext.Cars.ToListAsync();
            if (foundCars == null)
                return null;
            return foundCars;
        }

        public async Task<Car> GetCarById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Car> UpdateCar(int id, Car carToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
