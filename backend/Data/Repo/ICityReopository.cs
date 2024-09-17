using web_api.Models;

namespace web_api.Data.Repo
{
    public interface ICityReopository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        void AddCity(City city);

        void DeleteCity(int cityId);

        Task<bool> SaveAsync();
    }
}
