using System.Collections;
using web_api.Models;

namespace web_api.Interfaces
{
    public interface IPropertyTypeRepository
    {
        Task<IEnumerable<PropertyType>> GetPropertyTypeAsync();
    }
}
