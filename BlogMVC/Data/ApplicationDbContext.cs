using System;
using BlogMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Race> Races { get; set; }

		public DbSet<Club> Clubs { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}

