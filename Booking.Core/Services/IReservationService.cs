using Booking.Core.Dto;
using Booking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDetailsDto>> GetAllWithTrip(string host);
        Task<Reservation> GetReservationById(int id);
        Task<IEnumerable<Reservation>> GetReservationByTripId(int tripId);
        Task<Reservation> CreateReservation(Reservation newReservation);
        Task UpdateReservation(Reservation reservationoBeUpdated, Reservation reservation);
        Task DeleteReservation(Reservation reservation);
    }
}
