
using Application.Dtos;
using Domain.Repositories;

namespace Application.Services.Accounts
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task CreateUser(AccountDto user)
        {
            var username = user.Username;
            var password = user.Password;

            var existingUser = await _accountRepository.GetUserByUsernameAndPassword(username, password);

            if (existingUser != null)
                throw new Exception("There is a user with same information.");

            await _accountRepository.CreateUser(username, password);
        }

        public string GenerateToken(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
