using Booking.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booking.Core.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public Guid ReservedBy { get; set; }
        [ForeignKey(nameof(ReservedBy))]
        public User User { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public int TripId{ get; set; }

        [ForeignKey(nameof(TripId))]
        public Trip Trip { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
    }
}
