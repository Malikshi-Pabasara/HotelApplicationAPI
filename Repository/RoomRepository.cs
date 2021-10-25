using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelApplication.Data;
using HotelApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApplication.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;
        public RoomRepository(HotelContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoomModel>> GetAllRoomsAsync()
        {
            var records = await _context.Rooms.ToListAsync();
            return _mapper.Map<List<RoomModel>>(records); //Auto Map the record
        }

        public async Task<RoomModel> GetRoomByIdAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            return _mapper.Map<RoomModel>(room);
        }

        public async Task<int> AddRoomAsync(RoomModel roomModel)
        {
            var room = new Room()
            {
                FeatureId = roomModel.FeatureId,
                PriceId = roomModel.PriceId,
                PropertyId = roomModel.PropertyId,
                IsActive = roomModel.IsActive,
                RoomNo = roomModel.RoomNo,
                RoomType = roomModel.RoomType,
                RoomStatus = roomModel.RoomStatus
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return room.RoomId;
        }
        public async Task UpdateRoomAsync(int roomId, RoomModel roomModel)
        {
            var room = new Room()
            {
                RoomId = roomId,
                FeatureId = roomModel.FeatureId,
                PriceId = roomModel.PriceId,
                PropertyId = roomModel.PropertyId,
                IsActive = roomModel.IsActive,
                RoomNo = roomModel.RoomNo,
                RoomType = roomModel.RoomType,
                RoomStatus = roomModel.RoomStatus
            };

            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int roomId)
        {
            var room = new Room()
            {
                RoomId = roomId
            };

            _context.Rooms.Remove(room);

            await _context.SaveChangesAsync();
        }
    }
}
