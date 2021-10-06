using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IReservationRepository Reservations { get; }
        ITripRepository Trips { get; }
        Task<int> CommitAsync();
    }
}
