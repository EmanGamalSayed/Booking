using Booking.Core.Dto;
using Booking.Core.Models;
using Booking.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<ReservationDetailsDto>> GetAllWithTripAsync(string host)
        {
            return await ApplicationDbContext.Reservations
                .Include(m => m.Trip).Include(m => m.User).Select(x=> new ReservationDetailsDto
                {
                    Id = x.Id,
                    CustomerName = x.CustomerName,
                    ReservedBy = x.User.Email,
                    ReservationDate = x.ReservationDate,
                    TripId = x.TripId,
                    TripName = x.Trip.Name,
                    Price = x.Trip.Price,
                    CityName = x.Trip.CityName,
                    ImageUrl = host + "/" + x.Trip.ImageUrl,
                    Notes = x.Notes,
                    ContentTrip = WebUtility.HtmlDecode(x.Trip.Content) 
                })
                .ToListAsync();
        }

        public async Task<Reservation> GetWithTripByIdAsync(int id)
        {
            return await ApplicationDbContext.Reservations
                .Include(m => m.Trip)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Reservation>> GetAllWithTripByTripIdAsync(int tripId)
        {
            return await ApplicationDbContext.Reservations
                .Include(m => m.Trip)
                .Where(m => m.TripId == tripId)
                .ToListAsync();
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}