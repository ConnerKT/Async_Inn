using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
	public class RoomAmen
	{
		[Key]

		public int Id { get; set; }
		[Required]

		public int RoomsId { get; set; }
        [Required]

        public int AmenId { get; set; }
    }
}

