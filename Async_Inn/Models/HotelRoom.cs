using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
	public class HotelRoom
	{
        [Key]

        public int ID { get; set; }
        [Required]

        public int HotelID { get; set; }

        public int RoomID { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

    }
}

