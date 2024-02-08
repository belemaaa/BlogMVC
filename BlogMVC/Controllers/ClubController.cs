﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMVC.Data;
using BlogMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Detail(int id)
        {
            Club club = _context.Clubs.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
            return View(club);
        }
    }

}

