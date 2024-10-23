using BusinessLogic.Services.Interface;
using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shered.DTOs;

namespace BookReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("GetAllReservations")]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            if (reservations == null || !reservations.Any())
            {
                return NotFound("No reservations found.");
            }
            return Ok(reservations);
        }

        [HttpGet("GetReservationById/{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound($"Reservation with ID {id} not found.");
            }
            return Ok(reservation);
        }
        [HttpPost("AddReservation")]
        public async Task<IActionResult> AddReservation([FromBody] ReservationDTO reservationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation = await _reservationService.AddReservationAsync(reservationDto);

            return Ok(reservation); 
        }
        [HttpDelete("DeleteReservation/{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            try
            {
                await _reservationService.DeleteReservationAsync(id);
                return Ok("Reservation deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); 
            }
        }
    }
}
