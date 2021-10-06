using Booking.Core.Models;
using Booking.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data.Repositories
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(ApplicationDbContext context)
            : base(context)
        { }
        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public new async Task<Trip> GetByIdAsync(int id)
        {
            var trip = await ApplicationDbContext.Trips
                .SingleOrDefaultAsync(m => m.Id == id);
            //trip.ImageUrl = Path.Combine(Directory.GetCurrentDirectory(), trip.ImageUrl);
            trip.Content = WebUtility.HtmlDecode(trip.Content);
            return trip;
        }
    }
}