using Microsoft.IdentityModel.Tokens;
using notaria.DataEntities;
using notaria.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace notaria.Helpers
{
    public class JwtServices
    {
        IConfiguration configuration;

        public JwtServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Generate(UserEntity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.nombre+" "+user.apellido),
                    new Claim(ClaimTypes.Email, user.correo),
                    new Claim(ClaimTypes.GivenName, user.apellido),
                    new Claim(ClaimTypes.Surname, user.nombre),
                    new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(this.configuration["Jwt:Issuer"],
              this.configuration["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            var tokenReturn = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenReturn;
        }
    }
}
