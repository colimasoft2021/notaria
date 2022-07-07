using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notaria.DataContext;
using notaria.DataEntities;
using notaria.Helpers;
using notaria.Models;
using System.Security.Cryptography;
using System.Text;

namespace notaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly NotariaContext _context;
        private readonly JwtServices _jwtService;

        public UsuarioController(NotariaContext context, JwtServices JwtService)
        {
            _context = context;
            _jwtService = JwtService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //var jwt = Request.Cookies["jwt"];
                //var token = _jwtService.Verify(jwt);

                var users = _context.Users.Where(x => x.Activo ==  true).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        // crea Usuarioos
        [HttpPost("/api/Usuario/CrearUser")]
        public IActionResult CrearUsuario([FromBody] UserModel model)
        {
            var message = new { status = "", message = "" };
            IActionResult ret = null;
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                var user = new UserEntity();
                user.nombre = model.nombre;
                user.apellido = model.apellido;
                user.correo = model.correo;
                user.clave = hashClave(model.clave);
                user.Activo = true;
                user.modificar = model.modificar;
                user.rolId = 2;

                var exist = _context.Users.Where(x => x.correo == user.correo).FirstOrDefault();

                if (exist != null && exist.Activo == true)
                {
                    message = new { status = "Advertencia", message = "Usuario registrado" };
                    ret = StatusCode(StatusCodes.Status500InternalServerError, message);
                }
                if (exist != null && exist.Activo == false )
                {
                    var bitData = new UserEntity();
                    bitData.id = exist.id;
                    bitData.Activo = true;
                    bitData.clave = hashClave(model.clave);
                    _context.Update(user);
                    _context.SaveChanges();
                    message = new { status = "Ok", message = "Usuario Creado" };
                    ret = StatusCode(StatusCodes.Status201Created, message);
                }
                else
                {
                    _context.Add(user);
                    _context.SaveChanges();
                    message = new { status = "Ok", message = "Usuario "+user.nombre+" "+user.apellido+"se ha creado" };
                    ret = StatusCode(StatusCodes.Status201Created, message);
                }

                return ret;

            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        //Verifaca el corre y la contraseña esxistan
        //[HttpPost("/api/Usuario/Login")]
        [HttpPost()]
        public IActionResult Login([FromBody] UserModel model)
        {
            var message = new { status = "", message = "", data="" };
            IActionResult ret = null;
            try
            {
                var user = new UserEntity();
                user.id = model.id;
                user.correo = model.correo;
                user.clave = hashClave(model.clave);

                var exist = _context.Users.Where(x => x.correo == user.correo && x.clave == user.clave && x.Activo == true).FirstOrDefault();

                if (exist == null)
                {
                    return BadRequest("Credenciales incorrectas");
                }

                var jwt = _jwtService.Generate(exist.id);

                Response.Cookies.Append(key: "jwt", value: jwt, new CookieOptions
                {
                    HttpOnly = true
                });

                if (exist != null && exist.Activo == true)
                {
                    message = new { status = "Ok", message = "Usuario encontrado", data= jwt };
                    ret = StatusCode(StatusCodes.Status200OK, message);
                }
                else
                {
                    message = new { status = "Error", message = "Usuario y/o contraseña no coinciden", data ="" };
                    ret = StatusCode(StatusCodes.Status500InternalServerError, message);
                }

                return ret;

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut()]
        public IActionResult Modificar([FromBody] UserModel update)
        {
            var message = new { status = "", message = "" };
            IActionResult ret = null;
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

               var exist = _context.Users.Where(x => x.id == update.id).AsNoTracking().FirstOrDefault();

               var correo = _context.Users.Where(x => x.correo == update.correo).AsNoTracking().FirstOrDefault();

                if( correo.correo == update.correo)
                {
                    //message = new { status = "Eroror", message = "El correo ingresado ya ha sido registrado antes, confirmalo con el Administrador" };
                    //ret = StatusCode(StatusCodes.Status400BadRequest, message);
                    return BadRequest("El correo ingresado ya ha sido registrado antes, confirmalo con el Administrador");
                }
                string newClave = "";
                if ( hashClave(update.clave) != exist.clave)
                {
                    newClave = hashClave(update.clave);
                }
                else
                {
                    newClave = exist.clave;
                }
                if (exist != null && exist.Activo == true)
                {
                    var userData =  new UserEntity();
                    userData.id = update.id;
                    userData.nombre = update.nombre;
                    userData.apellido = update.apellido;
                    userData.correo = update.correo;
                    userData.clave = newClave;
                    userData.modificar = update.modificar;
                    userData.Activo = true;

                    userData.rolId = exist.rolId;

                    //_context.Update(user);
                    _context.Update(userData);
                    _context.SaveChanges();

                    message = new { status = "Ok", message = "Usuario modificado" };
                    ret = StatusCode(StatusCodes.Status201Created, message);
                }

                return ret;
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete]
        public IActionResult BajaUsario(int id)
        {
            var message = new { status = "", message = "" };
            IActionResult ret = null;

            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                var exists = _context.Users.Find(id);

                if (exists != null && exists.Activo == true)
                {
                    var update = new UserEntity();
                    update.id = id;
                    update.Activo = false;

                    _context.Users.Update(update);
                    _context.SaveChanges();

                    message = new { status = "Ok", message = "El usuario sea eliminado" };
                    ret = StatusCode(StatusCodes.Status201Created, message);
                }
                else
                {
                    message = new { status = "Ok", message = "Usuario eliminado" };
                    ret = StatusCode(StatusCodes.Status200OK, message);
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
