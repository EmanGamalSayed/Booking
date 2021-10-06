using Booking.Core.Dto;
using Booking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<IEnumerable<ReservationDetailsDto>> GetAllWithTripAsync(string host);
        Task<Reservation> GetWithTripByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetAllWithTripByTripIdAsync(int tripId);

    }
}
