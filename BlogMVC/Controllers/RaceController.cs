using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMVC.Data;
using BlogMVC.Interfaces;
using BlogMVC.Models;
using BlogMVC.Repository;
using BlogMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;

        public RaceController(IRaceRepository raceRepository, IPhotoService photoService)
        {
            this._raceRepository = raceRepository;
            this._photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceViewModel raceVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(raceVM.Image);
                var race = new Race
                {
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = raceVM.Address.Street,
                        City = raceVM.Address.City,
                        State = raceVM.Address.State
                    }
                };
                _raceRepository.Add(race);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo Upload failed");
            }

            return View(raceVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var race = await _raceRepository.GetByIdAsync(id);
            if (race == null)
                return View("Error");
            var raceVM = new EditRaceViewModel
            {
                Title = race.Title,
                Description = race.Description,
                URL = race.Image,
                RaceCategory = race.RaceCategory,
                AddressId = race.AddressId,
                Address = race.Address
            };
            return View(raceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRaceViewModel raceVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to update race object");
                return View("Edit", raceVM);
            }
            var userRace = await _raceRepository.GetByIdAsyncNoTracking(id);
            if (userRace != null)
            {
                string? uploadedImage = null;
                if (raceVM.Image != null && raceVM.Image.Length > 0)
                {
                    try
                    {
                        await _photoService.DeletePhotoAsync(userRace.Image);
                        var photoResult = await _photoService.AddPhotoAsync(raceVM.Image);
                        if (photoResult != null)
                        {
                            uploadedImage = photoResult.Url.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View(raceVM);
                    }
                }
                else
                {
                    uploadedImage = userRace.Image;
                }

                var race = new Race
                {
                    Id = id,
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    Image = uploadedImage,
                    RaceCategory = raceVM.RaceCategory,
                    AddressId = raceVM.AddressId,
                    Address = raceVM.Address
                };
                _raceRepository.Update(race);
                return RedirectToAction("Index");
            }
            else
            {
                return View(raceVM);
            }

        }
    }
}

