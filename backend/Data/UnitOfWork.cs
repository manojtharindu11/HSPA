using web_api.Interfaces;
using web_api.Repo;

namespace web_api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ICityReopository cityReopository => new CityRepository(_dataContext);

        public IUserRepository userRepository => new UserRepository(_dataContext);

        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
