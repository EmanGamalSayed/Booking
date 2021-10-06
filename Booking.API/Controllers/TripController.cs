using AutoMapper;
using Booking.API.Models;
using Booking.Core.Models;
using Booking.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;
        public TripController(ITripService tripService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._mapper = mapper;
            this._tripService = tripService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Trip>>> GetAll()
        {
            var Trips = await _tripService.GetAll();
            var mappedTrips = _mapper.Map<IEnumerable<Trip>, IEnumerable<TripDropdown>>(Trips);

            return Ok(mappedTrips);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetById(int id)
        {
            var trip = await _tripService.GetById(id);
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            //trip.ImageUrl = Path.Combine(host, trip.ImageUrl);
            trip.ImageUrl = host + "/" +trip.ImageUrl;
            var mappedTrips = _mapper.Map<Trip, TripModel>(trip);

            return Ok(mappedTrips);
        }

        
    }
}
