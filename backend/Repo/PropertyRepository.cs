using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Repo
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext dataContext;

        public PropertyRepository(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public void AddProperty(Property property)
        {
            dataContext.Properties.Add(property);
        }

        public void DeleteProperty(int propertyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetAllPropertiesAsync(int sellRent)
        {
            var properties = await dataContext.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.City)
                .Include(p => p.FurnishingType)
                .Include(p => p.Photos)
                .Where(p => p.SellRent == sellRent)
                .ToListAsync();
            return properties;
        }

        public async Task<Property> GetPropertyDetailAsync(int id)
        {
            var property = await dataContext.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.City)
                .Include(p => p.FurnishingType)
                .Include (p => p.Photos)
                .Where(p => p.Id == id)
                .FirstAsync();
            return property;
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            var property = await dataContext.Properties
                .Include(p => p.Photos)
                .Where(p => p.Id == id)
                .FirstAsync();
            return property;
        }
    }
}
