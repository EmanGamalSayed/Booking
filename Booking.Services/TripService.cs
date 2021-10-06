using Booking.Core.Models;
using Booking.Core.Repositories;
using Booking.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class TripService : ITripService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TripService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Trip> CreateTrip(Trip newTrip)
        {
            await _unitOfWork.Trips.AddAsync(newTrip);
            await _unitOfWork.CommitAsync();
            return newTrip;
        }

        public async Task DeleteTrip(Trip trip)
        {
            _unitOfWork.Trips.Remove(trip);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _unitOfWork.Trips
                .GetAllAsync();
        }

        public async Task<Trip> GetById(int id)
        {
            return await _unitOfWork.Trips
                .GetByIdAsync(id);
        }

    }
}
