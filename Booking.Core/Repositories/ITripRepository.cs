using Booking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Repositories
{
    public interface ITripRepository : IRepository<Trip>
    {
        public new Task<Trip> GetByIdAsync(int id);
    }
}
