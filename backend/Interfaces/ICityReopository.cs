using web_api.Models;

namespace web_api.Interfaces
{
    public interface ICityReopository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        void AddCity(City city);

        void DeleteCity(int cityId);
    }
}
