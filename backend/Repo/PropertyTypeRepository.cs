using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Repo
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly DataContext dataContext;

        public PropertyTypeRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IEnumerable<PropertyType>> GetPropertyTypeAsync()
        {
            return await dataContext.PropertyTypes.ToListAsync();
        }
    }
}
