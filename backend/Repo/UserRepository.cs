using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Interfaces;
using web_api.Models;

namespace web_api.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dc;

        public UserRepository(DataContext dataContext)
        {
            dc = dataContext;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await dc.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }
    }
}
