using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RoomsAPI.Models;
using RoomsAPI.Repository;
using System.Threading.Tasks;

namespace RoomsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllRooms()
        { 
            var rooms = await _roomRepository.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomsById( [FromRoute]int id)
        {
            var room = await _roomRepository.GetRoomsByIdAsync(id);
            if(room == null)
            {
                return NotFound();
            }
            return Ok(room);

        }

        [HttpPost("")]
        public async Task<IActionResult> AddRoomAsync([FromBody] RoomModel roomModel) 
        {
             var id = await _roomRepository.AddRoomAsync(roomModel);
             return CreatedAtAction(nameof(GetRoomsById), new { id = id, Controller = "Rooms" }, id);
            //return Ok("OK"); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomModel roomModel, [FromRoute] int id)
        {
            var room = await _roomRepository.UpdateRoomAsync(id,roomModel);
            return Ok(room);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRoomPatch([FromBody] JsonPatchDocument roomModel, int id)
        {
            await _roomRepository.UpdateRoomPatchAsync(id, roomModel);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom( int id)
        {
            await _roomRepository.DeleteRoomAsync(id);
            return Ok();
        }

 
        [HttpPatch("CleanRoom/{id}")]
        public async Task<IActionResult> CleanRoom([FromBody] JsonPatchDocument roomModel, int id)
        {
            await _roomRepository.CleanRoomAsync(id, roomModel);
            return Ok();

        }

        [HttpGet("status/{id}/{status}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] string status, int id)
        {
            await _roomRepository.UpdateRoomStatus(id, status);
            return Ok();

        }

    }
}
