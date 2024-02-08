using System;
using System.ComponentModel.DataAnnotations;
using BlogMVC.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogMVC.Models
{
	public class Race
	{
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public RaceCategory RaceCategory { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

    }
}

