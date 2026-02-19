using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDormApi.Data; 
using SmartDormApi.Models;

namespace SmartDormApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {

            return await _context.Rooms
                                 .Include(r => r.CurrentTenant)
                                 .OrderBy(r => r.RoomNumber)
                                 .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.Include(r => r.CurrentTenant).FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRooms), new { id = room.Id }, room);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound(); 
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id) return BadRequest();

            var existingRoom = await _context.Rooms
                .Include(r => r.CurrentTenant)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (existingRoom == null) return NotFound();

            existingRoom.Status = room.Status;
            existingRoom.Type = room.Type;
            existingRoom.MonthlyRent = room.MonthlyRent;

            if (room.CurrentTenant != null)
            {
                if (existingRoom.CurrentTenant == null)
                {
                    existingRoom.CurrentTenant = room.CurrentTenant;
                }
                else
                {
                    existingRoom.CurrentTenant.Name = room.CurrentTenant.Name;
                    existingRoom.CurrentTenant.PhoneNumber = room.CurrentTenant.PhoneNumber;
                }
            }
            else if (room.Status == "Available")
            {
                if (existingRoom.CurrentTenant != null)
                {
                    _context.Tenants.Remove(existingRoom.CurrentTenant);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Rooms.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();

        }
    }
}