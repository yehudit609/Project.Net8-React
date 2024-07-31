using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> AddCar(Car car)
        {
            // Implement the logic to add a new car using the repository
            return await _carRepository.AddCar(car);
        }

        public async Task<List<Car>> GetCars()
        {
            // Implement the logic to get all cars using the repository
            return await _carRepository.GetCars();
        }

       

        public async Task<Car> DeleteCar(int id)
        {
            return await _carRepository.DeleteCar(id);
        }
    }
}
