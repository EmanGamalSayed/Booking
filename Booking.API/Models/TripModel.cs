using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Models
{
    public class TripModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class TripDropdown
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
   
}
