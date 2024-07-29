using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICarService
    {
        Task<Car> AddCar(Car car);
        Task<List<Car>> GetCars();
        Task<Car> GetCarById(int id);
       
    }
}
