using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMVC.Data;
using Microsoft.AspNetCore.Mvc;


namespace BlogMVC.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext context;

        public ClubController(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}

