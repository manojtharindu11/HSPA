using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api.Data.Repo
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

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
