using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlogMVC.Models
{
	public class User : IdentityUser
	{
		public int? Pace { get; set; }

		public int? Mileage { get; set; }

		[ForeignKey("Address")]

		public int AddressId { get; set; }

		public Address? Address { get; set; }

		public ICollection<Club> Clubs { get; set; }

		public ICollection<Race> Race { get; set; }
	}
}

