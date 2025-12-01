
using Application.Dtos;

namespace Application.Services.Accounts
{
    public interface IAccountService
    {

        Task CreateUser(AccountDto user);

        string GenerateToken(int userId);

        Task<AccountDto> GetUserByUsernameAndPassword(string username, string password);

    }
}
