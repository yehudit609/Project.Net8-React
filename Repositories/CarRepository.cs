
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

        //public async Task<Car> DeleteCar(int id)
        //{
        //    var carToDelete = await _CarRetalContext.Cars.FindAsync(id);

        //    if (carToDelete == null)
        //    {
        //        return null; // Car not found, return null or handle accordingly
        //    }

        //    _CarRetalContext.Cars.Remove(carToDelete);
        //    await _CarRetalContext.SaveChangesAsync();

        //    return carToDelete;
        //}

        public async Task<Car> DeleteCar(int id)
        {
            var carToDelete = _CarRetalContext.Cars.Include(c => c.Rentings).FirstOrDefault(c => c.CarId == id);

            if (carToDelete != null)
            {
                _CarRetalContext.Rentings.RemoveRange(carToDelete.Rentings);
                _CarRetalContext.Cars.Remove(carToDelete);
                _CarRetalContext.SaveChanges();
            }
            return carToDelete;
        }





    }
}
