using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        private SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration { get; }
        public LoginService(IUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        public async Task<object> findByLogin(LoginDto user)
        {
            var baseUser = new UserEntity();

            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                    );

                    DateTime createdate = DateTime.Now;
                    DateTime expirationDate = createdate + TimeSpan.FromSeconds(Convert.ToUInt32(Environment.GetEnvironmentVariable("Seconds")));

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createdate, expirationDate, handler);
                    return SuccessObject(createdate, expirationDate, token, baseUser);

                }
            }
            else
            {
                return null;
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createdate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                created = createdate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                UserName = user.Email,
                name = user.Name,
                message = "Usuário Logado com sucesso"
            };
        }
    }
}
