using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly AsyncInnContext _context;

        public RoomController(AsyncInnContext context)
        {
            _context = context;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
        {
          if (_context.Room == null)
          {
              return NotFound();
          }
            return await _context.Room.ToListAsync();
        }

        // GET: api/Room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
          if (_context.Room == null)
          {
              return NotFound();
          }
            var room = await _context.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }
            var sending = new Room() { ID = room.ID, Name = null, Layout = room.Layout };

            return sending;
        }

        // PUT: api/Room/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Room
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
          if (_context.Room == null)
          {
              return Problem("Entity set 'AsyncInnContext.Room'  is null.");
          }
            _context.Room.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (_context.Room == null)
            {
                return NotFound();
            }
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //[Route("{roomId}/Amenity/{amenityId}")]
        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            if (_context.RoomAmens == null)
            {
                return Problem("AsyncInnContext is Null");
            }

            var amen = _context.Amen.FindAsync(amenityId);
            if (amen == null)
            {
                return Problem("That Amentity ID doesn't exist");
            }
            var room = _context.Rooms.FindAsync(roomId);
            if (room == null)
            {
                return Problem("That room ID doesn't exist");
            }
            RoomAmen newRoomAmen = new RoomAmen();
            try
            {
                newRoomAmen = _context.RoomAmens.Add(new RoomAmen { AmenID = amenityId, RoomsId = roomId }).Entity;
            }
            catch (Exception)
            {
                throw new Exception("There was an error!");
            }
            finally
            {
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("PostAmenityToRoom", newRoomAmen.ID, newRoomAmen);

        }
        [HttpDelete]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            if (_context.RoomAmens == null)
            {
                return Problem("AsyncInnContext is Null");
            }

            var amen = _context.Amen.FindAsync(amenityId);
            if (amen == null)
            {
                return Problem("That Amentity ID doesn't exist");
            }
            var room = _context.Rooms.FindAsync(roomId);
            if (room == null)
            {
                return Problem("That room ID doesn't exist");
            }

                try
                {

                    RoomAmen amenToRemove= await _context.RoomAmens.FindAsync(new { AmenityID = amenityId, RoomID = roomId });

                    _context.RoomAmens.Remove(amenToRemove);
                }

                catch (Exception)
                {
                throw new Exception("Can not remove");
                }
                finally
                {
                //Finally saves the changes into the context
                    await _context.SaveChangesAsync();
                }
                return Ok();

            }

        private bool RoomExists(int id)
        {
            return (_context.Room?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
