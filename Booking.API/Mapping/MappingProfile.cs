using AutoMapper;
using Booking.API.Models;
using Booking.Core.Dto;
using Booking.Core.Models;

namespace Booking.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReservationDetailsDto, ReservationDetailsModel>();
            CreateMap<Reservation, ReservationDetailsModel>();
            CreateMap<ReservationModel, Reservation>().ReverseMap();
            
            CreateMap<Trip, TripModel>().ReverseMap();
            CreateMap<Trip, TripDropdown>().ReverseMap();

        }
    }
}
