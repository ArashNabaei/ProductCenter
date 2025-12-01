
using Application.Dtos;
using AutoMapper;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Accounts
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;

        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _mapper = mapper;
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
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                }),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<double>("Jwt:ExpiryMinutes")),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<AccountDto> GetUserByUsernameAndPassword(string username, string password)
        {
            var user = await _accountRepository.GetUserByUsernameAndPassword(username, password);

            var userDto = _mapper.Map<AccountDto> (user);

            return userDto;
        }

        public async Task<int> ValidateUser(string username, string password)
        {
            var user = await _accountRepository.GetUserByUsernameAndPassword(username, password);

            if (user == null)
                throw new Exception("There is no user with with these information.");

            return user.Id;
        }

    }
}
