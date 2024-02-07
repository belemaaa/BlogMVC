using System;
using BlogMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Race> Races { get; set; }

		public DbSet<Club> Clubs { get; set; }

        public DbSet<Address> Addresses { get; set; }


    }
}

