using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
	public class Amen
	{
		[Key]
		public int Id { get; set; }
		[Required]

		public string NameOfAmen { get; set; }
	}
}

