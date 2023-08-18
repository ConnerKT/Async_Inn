using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
	public class RoomAmen
	{
		[Key]

		public int ID { get; set; }
		[Required]

		public int RoomsId { get; set; }
        [Required]

        public int AmenID { get; set; }

        public Room? Room { get; set; }

        public Amen? Amenity { get; set; }
    }
}

