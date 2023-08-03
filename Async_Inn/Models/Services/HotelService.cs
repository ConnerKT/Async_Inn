using System;
using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models.Services
{
    public class HotelService : IHotel
    {
        private AsyncInnContext _context;
        

        public HotelService(AsyncInnContext context)
        {
            _context = context;
        }

        async Task<IActionResult> IHotel.DeleteHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
            return null;
        }

        async Task<ActionResult<IEnumerable<Hotel>>> IHotel.GetHotel()
        {
            return await _context.Hotel.ToListAsync();
        }

        async Task<ActionResult<Hotel>> IHotel.GetHotel(int id)
        {
            return await _context.Hotel.FindAsync(id);
        }

        bool IHotel.hotelExists(int id)
        {
            return (_context.Hotel?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        async Task<ActionResult<Hotel>> IHotel.PostHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
            
        }

         async Task<IActionResult> IHotel.PutHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return null;
        }
    }
}

