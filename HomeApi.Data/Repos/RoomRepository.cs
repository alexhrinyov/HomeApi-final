using System;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.Data.Models;
using HomeApi.Data.Queries;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HomeApi.Data.Repos
{
    /// <summary>
    /// Репозиторий для операций с объектами типа "Room" в базе
    /// </summary>
    public class RoomRepository : IRoomRepository
    {
        private readonly HomeApiContext _context;
        
        public RoomRepository (HomeApiContext context)
        {
            _context = context;
        }
        
        /// <summary>
        ///  Найти комнату по имени
        /// </summary>
        public async Task<Room> GetRoomByName(string name)
        {
            return await _context.Rooms.Where(r => r.Name == name).FirstOrDefaultAsync();
        }
        /// <summary>
        ///  Найти комнату по ID
        /// </summary>
        public async Task<Room> GetRoomById(Guid Id)
        {
            return await _context.Rooms.Where(r => r.Id == Id).FirstOrDefaultAsync();
        }
        /// <summary>
        ///  Найти все комнаты
        /// </summary>
        public async Task<Room[]> GetRooms()
        {
            return await _context.Rooms.ToArrayAsync();
        }

        /// <summary>
        ///  Добавить новую комнату
        /// </summary>
        public async Task AddRoom(Room room)
        {
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                await _context.Rooms.AddAsync(room);
            
            await _context.SaveChangesAsync();
        }
        /// <summary>
        ///  Перенастроить комнату
        /// </summary>
        public async Task ChangeRoom(Room room, UpdateRoomQuery newRoom)
        {
            room.Name = newRoom.NewName;
            room.Area = newRoom.NewArea;
            room.GasConnected = newRoom.NewGasConnected;
            room.Voltage = newRoom.NewVoltage;
          

            // Добавляем в базу 
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                _context.Rooms.Update(room);

            // Сохраняем изменения в базе 
            await _context.SaveChangesAsync();
        }


       
    }
}