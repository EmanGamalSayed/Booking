using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Core.Models.Auth
{
    public class User : IdentityUser<Guid>
    {
    }
}
