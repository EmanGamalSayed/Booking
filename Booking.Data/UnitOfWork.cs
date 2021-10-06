using Booking.Core.Repositories;
using Booking.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ReservationRepository _reservationRepository;
        private TripRepository _tripRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IReservationRepository Reservations => _reservationRepository = _reservationRepository ?? new ReservationRepository(_context);
        public ITripRepository Trips => _tripRepository = _tripRepository ?? new TripRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
