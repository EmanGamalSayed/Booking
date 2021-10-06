using Booking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Services
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> GetAll();
        Task<Trip> GetById(int id);
        Task<Trip> CreateTrip(Trip newTrip);
        Task DeleteTrip(Trip trip);
    }
}
