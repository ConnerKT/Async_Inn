using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Async_Inn.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string Id { get; set; }

        [Required]

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? Token { get; set; }

        [NotMapped]
        public IList<string>? Roles { get; set; }
    }
}

