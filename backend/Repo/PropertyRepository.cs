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
            throw new NotImplementedException();
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
                .Where(p => p.SellRent == sellRent)
                .ToListAsync();
            return properties;
        }

        public async Task<Property> GetPropertyDetailAsync(int id)
        {
            var properties = await dataContext.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.City)
                .Include(p => p.FurnishingType)
                .Where(p => p.Id == id)
                .FirstAsync();
            return properties;
        }
    }
}
