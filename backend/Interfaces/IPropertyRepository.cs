using web_api.Models;

namespace web_api.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync(int sellRent);

        void AddProperty(Property property);
        void DeleteProperty(int propertyId);
    }
}
