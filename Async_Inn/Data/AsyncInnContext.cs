using System;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Async_Inn.Data
{
	public class AsyncInnContext : IdentityDbContext
    {
		public DbSet<Amen> Amens;
		public DbSet<RoomAmen> RoomAmens;
        public DbSet<Room> Rooms;
		public DbSet<Hotel> Hotelsl;
		public DbSet<HotelRoom> HotelRoom;

		public AsyncInnContext(DbContextOptions<AsyncInnContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Information tables
            modelBuilder.Entity<Room>().HasData(new Room
			{ ID = 1, Layout = 0, Name = "Basic Room" });

			modelBuilder.Entity<Hotel>().HasData(new Hotel
			{ ID = 1, Address = "123 Sesame St", City = "Memphis", State = "TN",
			Name = "Memphis Inn", Phone = "901-222-2222"});

			modelBuilder.Entity<Amen>().HasData(new Amen
			{ ID = 1, NameOfAmen = "A/C" });

			// Reference Tables
			modelBuilder.Entity<RoomAmen>().HasData(new RoomAmen
			{ ID = 1, AmenID = 1, RoomsId = 1 });
			modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
			{ ID = 1, HotelID = 1, RoomID = 1,Name = "Express Room" ,Price = 120.99 });

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Async_Inn.Models.Hotel> Hotel { get; set; } = default!;

        public DbSet<Async_Inn.Models.Amen> Amen { get; set; } = default!;

        public DbSet<Async_Inn.Models.Room> Room { get; set; } = default!;
    }

}

