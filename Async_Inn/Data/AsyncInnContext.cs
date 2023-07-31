using System;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Data
{
	public class AsyncInnContext: DbContext
	{
		public DbSet<Amen> Amens;
		public DbSet<RoomAmen> RoomAmens;
        public DbSet<Room> Rooms;
		public DbSet<Hotel> Hotelsl;
		public DbSet<HotelRoom> HotelRooms;

		public AsyncInnContext(DbContextOptions<AsyncInnContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//Information tables
			modelBuilder.Entity<Room>().HasData(new Room
			{ Id = 1, Layout = 0, Name = "Basic Room" });

			modelBuilder.Entity<Hotel>().HasData(new Hotel
			{ Id = 1, Address = "123 Sesame St", City = "Memphis", State = "TN",
			Name = "Memphis Inn", Phone = "901-222-2222"});

			modelBuilder.Entity<Amen>().HasData(new Amen
			{ Id = 1, NameOfAmen = "A/C" });

			// Reference Tables
			modelBuilder.Entity<RoomAmen>().HasData(new RoomAmen
			{ Id = 1, AmenId = 1, RoomsId = 1 });
			modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
			{ Id = 1, HotelId = 1, RoomId = 1, Price = 120.99 });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Async_Inn.Models.Hotel> Hotel { get; set; } = default!;
    }

}

