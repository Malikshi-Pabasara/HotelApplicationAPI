using System.Threading.Tasks;
using HotelApplication.Models;
using HotelApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelApplication.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
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
        public async Task<IActionResult> GetRoomById([FromRoute] int id)
        {
            var room = await _roomRepository.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddRoom([FromBody] RoomModel roomModel)
        {
            var id = await _roomRepository.AddRoomAsync(roomModel);
            return CreatedAtAction(nameof(GetRoomById), new { id = id, controller = "Room" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomModel roomModel, [FromRoute] int id)
        {
            await _roomRepository.UpdateRoomAsync(id, roomModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom([FromRoute] int id)
        {
            await _roomRepository.DeleteRoomAsync(id);
            return Ok();
        }

    }
}
