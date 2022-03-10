using Microsoft.AspNetCore.JsonPatch;
using RoomsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomsAPI.Repository
{
    public interface IRoomRepository
    {
        Task<List<RoomModel>> GetAllRoomsAsync();
        Task<RoomModel> GetRoomsByIdAsync(int roomId);
        Task<int> AddRoomAsync(RoomModel roomModel);
        Task<int> UpdateRoomAsync(int roomId, RoomModel roomModel);
        Task UpdateRoomPatchAsync(int roomId, JsonPatchDocument roomModel);
        Task DeleteRoomAsync(int roomId);
        Task CleanRoomAsync(int roomId, JsonPatchDocument roomModel);
        Task UpdateRoomStatus(int roomId, string status);



    }
}
