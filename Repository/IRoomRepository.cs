using System.Collections.Generic;
using System.Threading.Tasks;
using HotelApplication.Models;

namespace HotelApplication.Repository
{
    public interface IRoomRepository
    {
        Task<List<RoomModel>> GetAllRoomsAsync();
        Task<RoomModel> GetRoomByIdAsync(int roomId);
        Task<int> AddRoomAsync(RoomModel roomModel);
        Task UpdateRoomAsync(int roomId, RoomModel roomModel);
        Task DeleteRoomAsync(int roomId);

    }
}
