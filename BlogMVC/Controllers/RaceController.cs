using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMVC.Data;
using BlogMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace BlogMVC.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            List<Race> races = _context.Races.ToList();
            return View(races);
        }
    }
}

