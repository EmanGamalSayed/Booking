using Booking.Core.Models;
using Booking.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Data.DataInitializer
{
    public interface IDataInitializer
    {
        List<Role> SeedRoles();
        List<User> SeedUsers();
        List<UserRole> SeedUserRoles();
        List<Trip> SeedTrips();
    }
}
