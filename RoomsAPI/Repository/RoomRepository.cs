using RoomsAPI.Data;
using RoomsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace RoomsAPI.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomsContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(RoomsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoomModel>> GetAllRoomsAsync()
        {
            /*
            var rooms = await _context.Rooms.Select(x => new RoomModel()
            {
                Id = x.Id,
                Type = x.Type,  
                RoomFeatures = x.RoomFeatures
              
            }).ToListAsync();
            return rooms;
            */

            var rooms = await _context.Rooms.Include(x => x.RoomFeatures).Select(x => new RoomModel()
            {
                Id = x.Id,
                Type = x.Type,
                RoomFeatures = x.RoomFeatures

            }).ToListAsync();
            return rooms;

            // var rooms = await _context.Rooms.ToListAsync();
            // return _mapper.Map<List<RoomModel>>(rooms);

        }

       
        public async Task<RoomModel> GetRoomsByIdAsync(int roomId)
        {
           // var room = await _context.Rooms.FindAsync(roomId);
           // return _mapper.Map<RoomModel>(room);

            var room = await _context.Rooms.Where(x => x.Id == roomId).Select(x => new RoomModel()
            {
                Id = roomId,
                Type=x.Type,
                RoomNo = x.RoomNo,
                PriceLbl=x.PriceLbl,
                Status = x.Status,
                RoomFeatures=x.RoomFeatures
            }) .FirstOrDefaultAsync();

            return room;
        }

        public async Task<int> AddRoomAsync(RoomModel roomModel)
        {
            //var mapper = _mapper.Map<Rooms>(roomModel);
            //_context.Rooms.Add(mapper);
            //await _context.SaveChangesAsync();
            //return mapper.Id;

            var room = new Rooms()
            {
                Type = roomModel.Type,
                RoomNo = roomModel.RoomNo,
                PriceLbl = roomModel.PriceLbl,
                Status = (roomModel.Status != null)? roomModel.Status : "Clean",
                RoomFeatures = roomModel.RoomFeatures
            };

            /*
            IList<RoomFeatures> RoomFeatures = new List<RoomFeatures>();

            foreach (object i in roomModel.RoomFeatures)
            {
                RoomFeatures.Add(new RoomFeatures { FeatureId = i });
            }
            */

          //  _context.RoomFeatures.Add(roomModel.RoomFeatures);

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();  
            return room.Id;

        }

        public async Task<int> UpdateRoomAsync(int roomId, RoomModel roomModel)
        {
        
            var room = new Rooms()
            {
                Id = roomId,
                Type = roomModel.Type,
                RoomNo = roomModel.RoomNo,
                Status = roomModel.Status,
                PriceLbl = roomModel.PriceLbl,
                RoomFeatures = roomModel.RoomFeatures

            };
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return room.Id;
           // return _mapper.Map<RoomModel>(room);

        }

        public async Task UpdateRoomPatchAsync(int roomId, JsonPatchDocument roomModel)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                roomModel.ApplyTo(room);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteRoomAsync(int roomId)
        {
            var room = new Rooms() { Id = roomId };

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }


        public async Task CleanRoomAsync(int roomId, JsonPatchDocument roomModel)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                roomModel.ApplyTo(room);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateRoomStatus(int roomId, string status)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                _context.Rooms.Attach(room);
                room.Status = status;
                _context.Entry(room).Property("Status").IsModified = true;
                _context.SaveChanges();

            }

        }



    }

}
