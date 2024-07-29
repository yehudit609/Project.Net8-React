using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICarRepository
    {
        Task<Car> AddCar(Car car);
        Task<List<Car>> GetCars();
        Task<Car> GetCarById(int id);
        
    }
}
