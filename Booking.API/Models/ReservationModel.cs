using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        //public Guid ReservedBy { get; set; }
        public string CustomerName { get; set; }
        public int TripId { get; set; }
        public DateTime ReservationDate { get; set; }
        //public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
    }
    public class ReservationDetailsModel
    {
        public int Id { get; set; }
        public string ReservedBy { get; set; }
        public string CustomerName { get; set; }
        public int TripId { get; set; }
        public string TripName { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public string CityName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ContentTrip { get; set; }
    }
}
