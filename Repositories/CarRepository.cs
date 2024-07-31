
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
        private CarRetalContext _CarRetalContext;

        public CarRepository(CarRetalContext CarRetalContext)
        {
            _CarRetalContext = CarRetalContext;
        }

        public async Task<Car> AddCar(Car car)
        {
            try
            {
                await _CarRetalContext.Cars.AddAsync(car);
                await _CarRetalContext.SaveChangesAsync();
                return car;
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public async Task<List<Car>> GetCars()
        {
            var foundCars = await _CarRetalContext.Cars.ToListAsync();
            if (foundCars == null)
                return null;
            return foundCars;
        }

        public async Task<Car> DeleteCar(int id)
        {
            var foundCar = await _CarRetalContext.Cars.FindAsync(id);
            if (foundCar == null)
                return null;
            await _CarRetalContext.SaveChangesAsync();
            return foundCar;
        }

        //public async Task<bool> DeleteCar(int id)
        //{
        //    var carToDelete = await _CarRetalContext.Cars.FindAsync(id);
        //    if (carToDelete == null)
        //    {
        //        return false; // Car not found
        //    }

        //    _CarRetalContext.Cars.Remove(carToDelete);
        //    await _CarRetalContext.SaveChangesAsync();

        //    return true; // Car successfully deleted
        //}

    }
}
