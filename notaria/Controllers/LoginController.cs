using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using notaria.DataContext;
using notaria.DataEntities;
using notaria.Helpers;
using notaria.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace notaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly NotariaContext _context;
        private readonly JwtServices _jwtService;
        private IConfiguration _config;

        public LoginController(NotariaContext context, JwtServices JwtService, IConfiguration config)
        {
            _context = context;
            _jwtService = JwtService;
            _config = config;
        }


        [AllowAnonymous]
        [HttpPost("/api/Login/Login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var message = new { status = "", message = "", data = "" };
            IActionResult ret = null;
            try
            {
                var user = new UserEntity();
                user.correo = model.correo;
                user.clave = hashClave(model.clave);

                var exist = _context.Users.Where(x => x.correo == user.correo && x.clave == user.clave && x.Activo == true).FirstOrDefault();
                if (exist == null)
                {
                    message = new { status = "Error", message = "Usuario y/o contraseña incorrectos", data = "" };
                    ret = StatusCode(StatusCodes.Status500InternalServerError, message);

                    return ret;
                }

                var jwt = _jwtService.Generate(exist);

                if (exist != null && exist.Activo == true)
                {
                    message = new { status = "Ok", message = "Usuario encontrado", data = jwt };
                    ret = StatusCode(StatusCodes.Status200OK, message);
                }
                else
                {
                    message = new { status = "Error", message = "Usuario y/o contraseña incorrectos", data = "" };
                    ret = StatusCode(StatusCodes.Status500InternalServerError, message);
                }

                return ret;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        string hashClave(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var HashedPassword = sha.ComputeHash(asByteArray);

            return Convert.ToBase64String(HashedPassword);
        }
    }
}