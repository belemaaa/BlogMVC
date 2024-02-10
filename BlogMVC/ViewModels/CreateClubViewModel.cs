using System;
using BlogMVC.Data.Enums;

namespace BlogMVC.ViewModels
{
	public class CreateClubViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public IFormFile Image { get; set; }
		public ClubCategory ClubCategory { get; set; }
	}
}

