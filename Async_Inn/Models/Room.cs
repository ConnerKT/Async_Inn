using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
	public class Room
	{
        [Key]
        
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public int Layout { get; set; }
    }
}

