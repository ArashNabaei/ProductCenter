
using Application.Services.Accounts;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using Shared.Exceptions.Accounts;
using Test.Mocks;

namespace Test.Services.Accounts
{
    public class AccountServiceTest
    {
        private readonly Mock<IAccountRepository> _accountRepository;

        private readonly IAccountService _accountService;

        public AccountServiceTest()
        {
            _accountRepository = new Mock<IAccountRepository>();

            _accountService = new AccountService(
                _accountRepository.Object,
                null, null);
        }

        [Fact]
        public async Task ValidateUser_WithInvalidCredentials_ShouldThrowsUserNotFoundException()
        {
            var user = AccountMocks.InvalidUser();

            _accountRepository.Setup(r => r.GetUserByUsernameAndPassword(user.Username, user.Password))
                              .ReturnsAsync((User?)null);

            var exception = await Assert.ThrowsAsync<AccountException>(() => _accountService.ValidateUser(user.Username, user.Password));

            Assert.Equal(1002, exception.Code);
        }

        [Fact]
        public async Task ValidateUser_WithValidCredentials_ShouldReturnsUserId()
        {
            var user = AccountMocks.ValidUser();

            _accountRepository.Setup(r => r.GetUserByUsernameAndPassword(user.Username, user.Password))
                              .ReturnsAsync(user);

            var result = await _accountService.ValidateUser(user.Username, user.Password);

            Assert.Equal(user.Id, result);
        }

    }
}
