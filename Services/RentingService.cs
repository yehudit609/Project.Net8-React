//using Entities;
//using Repositories;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Services
//{
//    public class RentingService : IRentingService
//    {
//        private readonly IRentingRepository _rentingRepository;

//        public RentingService(IRentingRepository rentingRepository)
//        {
//            _rentingRepository = rentingRepository;
//        }

//        public async Task<Renting> AddRenting(Renting renting)
//        {
//            // Implement the logic to add a new renting using the repository
//            return await _rentingRepository.AddRenting(renting);
//        }

//        public async Task<List<Renting>> GetRentings()
//        {
//            // Implement the logic to get all rentings using the repository
//            return await _rentingRepository.GetRentings();
//        }

//        public async Task<Renting> GetRentingById(int id)
//        {
//            // Implement the logic to get a renting by ID using the repository
//            return await _rentingRepository.GetRentingById(id);
//        }

//    }
//}

using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class RentingService : IRentingService
    {
        private readonly IRentingRepository _rentingRepository;

        public RentingService(IRentingRepository rentingRepository)
        {
            _rentingRepository = rentingRepository;
        }

        public async Task<Renting> AddRenting(Renting renting)
        {
            // Check if the vehicle is available for the specified date range before adding the rental
            bool isAvailable = await IsVehicleAvailable((int)renting.CarId, (DateOnly)renting.RentingDate, (DateOnly)renting.ReturnDate);

            if (isAvailable)
            {
                // Vehicle is available, proceed with adding the rental
                return await _rentingRepository.AddRenting(renting);
            }
            else
            {
                // Vehicle is not available for the specified date range, handle the scenario accordingly
                throw new Exception("Vehicle is not available for the specified date range");
            }
        }

        public async Task<List<Renting>> GetRentings()
        {
            // Implement the logic to get all rentings using the repository
            return await _rentingRepository.GetRentings();
        }

        public async Task<Renting> GetRentingById(int id)
        {
            // Implement the logic to get a renting by ID using the repository
            return await _rentingRepository.GetRentingById(id);
        }

        public async Task<bool> IsVehicleAvailable(int vehicleId, DateOnly RentingDate, DateOnly returnDate)
        {
            //// Implement the logic to check if the vehicle is available in the given date range
            //// You can call the repository method to fetch rentals and check for availability
            //// Example logic:
            //var rentals = await _rentingRepository.GetRentingsByVehicleId(vehicleId);
            //bool isAvailable = !rentals.Any(r => pickupDate < r.ReturnDate && returnDate > r.PickupDate);

            //return isAvailable;


            // Implement the logic to check if the vehicle is available in the given date range
            var rentals = await _rentingRepository.GetRentings(); // Fetch all rentals

            // Check if any existing rental conflicts with the specified date range
            bool isAvailable = !rentals.Any(r => r.CarId == vehicleId && RentingDate < r.ReturnDate && returnDate > r.RentingDate);

            return isAvailable;
        }
    }
}

