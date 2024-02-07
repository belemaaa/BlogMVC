using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMVC.Data;
using BlogMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace BlogMVC.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context)
        {
            this._context = context;
        }


        public IActionResult Index()
        {
            List<Club> clubs = _context.Clubs.ToList();
            return View(clubs);
        }
    }

}

