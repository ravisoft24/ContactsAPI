using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.Models;
using ReservationsAPI.Repository;
using RoomsAPI.Controllers;
using RoomsAPI.Repository;
using System.Threading.Tasks;

namespace ReservationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;

        public ReservationsController(IReservationRepository reservationRepository , IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationRepository.GetAllReservations();
            return Ok(reservations);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById([FromRoute] int id)
        {
            var reservation = await _reservationRepository.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewReservation([FromBody] ReservationModel reservationModel)
        {
            var id = await _reservationRepository.AddNewReservationAsync(reservationModel);
            return CreatedAtAction(nameof(GetReservationById), new { id = id, Controller = "Reservations" }, id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationModel reservationModel, [FromRoute] int id)
        {
            var reservation = await _reservationRepository.UpdateReservationAsync(id, reservationModel);
            return Ok(reservation);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateReservationPatch([FromBody] JsonPatchDocument reservationModel, [FromRoute] int id)
        {
            await _reservationRepository.UpdateReservationPatchAsync(id, reservationModel);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] int id)
        {
            await _reservationRepository.DeleteFeatureAsync(id);
            return Ok();
        }

        
        [HttpPatch("{id}/Manage")]
        public async Task<IActionResult> Manage([FromBody] JsonPatchDocument reservationModel, [FromRoute] int id)
        {
            var roomId = await _reservationRepository.Manage(id, reservationModel);
            if (roomId != 0)
            {
               // await _roomsRepository.UpdateRoomStatus(roomId,"Occupied"); 
            }
            return Ok();
        }
        

        [HttpGet("{id}/CheckIn")]
        public async Task<IActionResult> CheckIn([FromRoute] int id)
        {
            var roomId = await _reservationRepository.CheckIn(id);
            if (roomId != 0)
            {
                 await _roomRepository.UpdateRoomStatus(roomId,"Occupied");
               

            }
            return Ok(roomId);
        }

        [HttpGet("{id}/CheckOut")]
        public async Task<IActionResult> CheckOut([FromRoute] int id)
        {
            var roomId = await _reservationRepository.CheckOut(id);
            if (roomId != 0)
            {
                 await _roomRepository.UpdateRoomStatus(roomId,"Dirty");  

            }
            return Ok(roomId);
        }

    }
}
