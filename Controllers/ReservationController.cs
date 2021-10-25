using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApplication.Models;
using HotelApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelApplication.Controllers
{
    
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllReservations()
        {
            var Reservations = await _reservationRepository.GetAllReservationsAsync();
            return Ok(Reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById([FromRoute] int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddReservation([FromBody] ReservationModel reservationModel)
        {
            var id = await _reservationRepository.AddReservationAsync(reservationModel);
            return CreatedAtAction(nameof(GetReservationById), new { id = id, controller = "Reservation" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationModel reservationModel, [FromRoute] int id)
        {
            await _reservationRepository.UpdateReservationAsync(id, reservationModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] int id)
        {
            await _reservationRepository.DeleteReservationAsync(id);
            return Ok();
        }

    }
}
