using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Repo
{
    public class CityRepository : ICityReopository
    {
        private readonly DataContext _context;
        public CityRepository(DataContext dbContext)
        {
            _context = dbContext;
        }
        public void AddCity(City city)
        {
            _context.Cities.Add(city);
        }

        public void DeleteCity(int cityId)
        {
            var city = _context.Cities.FindAsync(cityId).Result;
            _context.Cities.Remove(city);
        }

        public async Task<City> FindCity(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
