using notaria.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using notaria.DataContext;
using notaria.DataEntities;
using Microsoft.EntityFrameworkCore;
using notaria.Models;
using System.Security.Cryptography;
using System.Text;

namespace notaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        IConfiguration configuration;
        private readonly NotariaContext _context;
        private readonly MailService _mailService;

        public ResetPasswordController(NotariaContext context, MailService mailService, IConfiguration configuration)
        {
            _context = context;
            _mailService = mailService;
            this.configuration = configuration;
        }

        private static Random random = new Random();

        [HttpGet()]
        public IActionResult MailResetPwd(string correo)
        {
            var message = new { status = "", message = "", data="" };
            IActionResult ret = null;

            try
            {
                var exist = _context.Users.Where(x => x.correo == correo && x.Activo == true).AsNoTracking().FirstOrDefault();
                if (exist == null)
                {
                    return BadRequest("Correo no valido, si el problema perisite informa al encargado del sistema");
                }
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var caracter = new string(Enumerable.Repeat(chars, 10)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                try
                {
                    _mailService.SendEmailGmail("erick.barreto@colimasoft.com", "Reset Pwd", caracter);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                var sendT = new TokenEntity();
                sendT.Token = caracter;
                sendT.Correo = correo;
                sendT.Confirmado = false;
                sendT.FechaCreado = DateTime.Now;
                
                _context.Tokens.Add(sendT);
                _context.SaveChanges();

                message = new { status = "Ok", message = "", data= caracter };
                ret = StatusCode(StatusCodes.Status200OK, message);

                return ret;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPost()]
        public IActionResult ConfirmPwd(confirmPwd model)
        {
            var message = new { status = "", message = ""};
            IActionResult ret = null;

            try
            {
                var expiracion = this.configuration["TimeExpiredTokenMail"];

                var existToken = _context.Tokens.Where(x => x.Token == model.token && x.Confirmado == false).AsNoTracking().FirstOrDefault();
                if (existToken == null)
                    return BadRequest("Token no valido");

                if (existToken != null)
                {
                    DateTime diaActual = DateTime.Now;
                    var fechaSolicitud = existToken.FechaCreado;
                    TimeSpan diferenciaDias = diaActual.Subtract((DateTime)fechaSolicitud);
                    if(diferenciaDias.Days > Convert.ToInt32(expiracion))
                    {
                        return BadRequest("Tiempo del token expirado");
                    }
                    existToken.Confirmado = true;
                    _context.Update(existToken);
                    _context.SaveChanges();

                    var usuario = _context.Users.Where(x => x.correo == existToken.Correo && x.Activo == true).AsNoTracking().FirstOrDefault();
                    usuario.clave = hashClave(model.clave);
                    _context.Update(usuario);
                    _context.SaveChanges();

                    message = new { status = "Ok", message = "Contraseña actualizada" };
                    ret = StatusCode(StatusCodes.Status200OK, message);
                }

                return ret;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        //Encriptacion de clave de usuario
        string hashClave(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var HashedPassword = sha.ComputeHash(asByteArray);

            return Convert.ToBase64String(HashedPassword);
        }
    }
}
