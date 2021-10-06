using AutoMapper;
using Booking.API.Models;
using Booking.API.Validations;
using Booking.Core.Dto;
using Booking.Core.Models;
using Booking.Core.Models.Auth;
using Booking.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReservationController(IReservationService reservationService,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            this._reservationService = reservationService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservations()
        {
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;

            var reservations = await _reservationService.GetAllWithTrip(host);
            var mappedReservations = _mapper.Map<IEnumerable<ReservationDetailsDto>, IEnumerable<ReservationDetailsModel>>(reservations);

            return Ok(mappedReservations);
        }

        [HttpPost("")]
        public async Task<ActionResult<ReservationDetailsModel>> CreateReservation([FromBody] ReservationModel model)
        {
            var validator = new ReservationModelValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var reservationToCreate = _mapper.Map<ReservationModel, Reservation>(model);
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            reservationToCreate.ReservedBy = Guid.Parse(currentUserId);
            reservationToCreate.CreationDate = DateTime.Now;
            var newReservation = await _reservationService.CreateReservation(reservationToCreate);

            var reservation = await _reservationService.GetReservationById(newReservation.Id);

            var reservationDetails = _mapper.Map<Reservation, ReservationDetailsModel>(reservation);

            return Ok(reservationDetails);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReservationModel>> UpdateReservation(int id, [FromBody] ReservationModel model)
        {
            var validator = new ReservationModelValidator();
            var validationResult = await validator.ValidateAsync(model);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var reservationToBeUpdate = await _reservationService.GetReservationById(id);

            if (reservationToBeUpdate == null)
                return NotFound();

            var reservation = _mapper.Map<ReservationModel, Reservation>(model);
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            reservation.ReservedBy = Guid.Parse(currentUserId);
            await _reservationService.UpdateReservation(reservationToBeUpdate, reservation);

            var updatedReservation = await _reservationService.GetReservationById(id);
            var updatedReservationMapped = _mapper.Map<Reservation, ReservationModel>(updatedReservation);

            return Ok(updatedReservationMapped);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            if (id == 0)
                return BadRequest();

            var reservation = await _reservationService.GetReservationById(id);

            if (reservation == null)
                return NotFound();

            await _reservationService.DeleteReservation(reservation);

            return Ok();
        }
    }
}
