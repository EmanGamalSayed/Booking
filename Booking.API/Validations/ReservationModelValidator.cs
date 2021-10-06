using Booking.API.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Validations
{
    public class ReservationModelValidator : AbstractValidator<ReservationModel>
    {
        public ReservationModelValidator()
        {
            RuleFor(m => m.TripId)
                .NotEmpty()
                .WithMessage("'Trip Id' must not be empty.");

            RuleFor(m => m.CustomerName)
                .NotEmpty()
                .WithMessage("'Customer Name' must not be empty.");
            
            RuleFor(m => m.ReservationDate)
                .NotEmpty()
                .WithMessage("'Reservation Date' is Required.");
        }
    }
}
