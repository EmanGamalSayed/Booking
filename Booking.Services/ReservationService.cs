using Booking.Core.Dto;
using Booking.Core.Models;
using Booking.Core.Repositories;
using Booking.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Reservation> CreateReservation(Reservation newReservation)
        {
            newReservation.CreationDate = DateTime.Now;
            await _unitOfWork.Reservations.AddAsync(newReservation);
            await _unitOfWork.CommitAsync();
            return newReservation;
        }

        public async Task DeleteReservation(Reservation reservation)
        {
            _unitOfWork.Reservations.Remove(reservation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ReservationDetailsDto>> GetAllWithTrip(string host)
        {
            return await _unitOfWork.Reservations
                .GetAllWithTripAsync(host);
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _unitOfWork.Reservations
                .GetWithTripByIdAsync(id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationByTripId(int tripId)
        {
            return await _unitOfWork.Reservations
                .GetAllWithTripByTripIdAsync(tripId);
        }

        public async Task UpdateReservation(Reservation ReservationToBeUpdated, Reservation reservation)
        {
            ReservationToBeUpdated.TripId = reservation.TripId;
            ReservationToBeUpdated.CustomerName = reservation.CustomerName;
            ReservationToBeUpdated.ReservationDate = reservation.ReservationDate;
            ReservationToBeUpdated.ReservedBy = reservation.ReservedBy;
            ReservationToBeUpdated.Notes = reservation.Notes;
            await _unitOfWork.CommitAsync();
        }
    }
}
