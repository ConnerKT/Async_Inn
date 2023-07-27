using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    //This is the table that we are containig those columns in
	public class Hotel
	{
        //This is declaring the columns in our database

        [Key]

		public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string State { get; set; }
        [Required]

        public string Phone { get; set; }


    }
}

