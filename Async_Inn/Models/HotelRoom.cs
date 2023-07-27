using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
	public class HotelRoom
	{
        [Key]

        public int Id { get; set; }
        [Required]

        public int HotelId{ get; set; }

        public int RoomId { get; set; }

        public double Price { get; set; }

    }
}

