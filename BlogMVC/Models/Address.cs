using System;
using System.ComponentModel.DataAnnotations;
namespace BlogMVC.Models
{
	public class Address
	{
		[Key] //primary key

		public int Id { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string state { get; set; }

		public Address()
		{
			
		}
	}
}

