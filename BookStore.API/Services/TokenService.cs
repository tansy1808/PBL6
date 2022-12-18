using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStore.API.DATA.Reponsitories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserReponsitory _userReponsitory;

        public TokenService(IConfiguration configuration, IUserReponsitory userReponsitory)
        {
            _configuration = configuration;
            _userReponsitory = userReponsitory;
        }
        public string CreateToken(string username)
        {
            IdentityOptions _options = new IdentityOptions();
            var user = _userReponsitory.GetUserByUsername(username);
            var role = _userReponsitory.GetRoleById(user.RoleId);

            var claims = new List<Claim>()
            {
                new Claim("iduser", user.IdUser.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId,username),
                new Claim("email", user.Email.ToString()),
                new Claim("name", user.Name.ToString()),
                new Claim("role", role.RoleName)

            };
            var symmetricKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["TokenKey"]));
 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    symmetricKey, SecurityAlgorithms.HmacSha512Signature)
            };
 
            var tokenHandler = new JwtSecurityTokenHandler();
 
            var token = tokenHandler.CreateToken(tokenDescriptor);
 
            return tokenHandler.WriteToken(token);
        }
    }
}