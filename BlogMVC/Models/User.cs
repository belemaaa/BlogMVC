using System;
namespace BlogMVC.Models
{
	public class User
	{
		public int? Pace { get; set; }
		public int? Mileage { get; set; }
		public Address? Address { get; set; }

		public ICollection<Club> Clubs { get; set; }
		public ICollection<Race> Race { get; set; }
	}
}

