using System;
using System.Linq;
using BlogMVC.Data;
using BlogMVC.Interfaces;
using BlogMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Repository
{
	public class RaceRepository : IRaceRepository
	{
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
		{
            this._context = context;
        }

        public bool Add(Race race)
        {
            this._context.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            this._context.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            return await _context.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await _context.Races.Include(a => a.Address).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Race> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Races.Include(a => a.Address).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool Save()
        {
            var saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race race)
        {
            this._context.Update(race);
            return Save();
        }
    }
}

