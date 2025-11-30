
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly EfContext _efcontext;

        public AccountRepository(EfContext efContext)
        {
            _efcontext = efContext;
        }

        public async Task CreateUser(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password
            };

            await _efcontext.Users.AddAsync(user);
            await _efcontext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByUsernameAndPassword(string username, string password)
        {
            var user = await _efcontext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            return user;
        }

    }
}
