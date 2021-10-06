using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booking.Core.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
