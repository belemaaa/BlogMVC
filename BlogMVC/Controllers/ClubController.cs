using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMVC.Data;
using BlogMVC.Interfaces;
using BlogMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            this._clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
            if (!(ModelState.IsValid))
            {
                return View(club);
            }
            _clubRepository.Add(club);
            Console.WriteLine("New club created successfully");

            return RedirectToAction("Index");
        }
    }

}

