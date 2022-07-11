using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using notaria.DataContext;
using notaria.Models;

namespace notaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoController : ControllerBase
    {
        private readonly NotariaContext _context;
        public ActoController(NotariaContext context)
        {
            _context = context;
        }
        [HttpGet("/api/Acto/obtenerTiposActo")] 
        public IActionResult ObtenerTiposActo()
        {
            try
            {
                var tipos = _context.TipoActo.ToList();
                return Ok(tipos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/api/Acto/obtenerActos")]
        public IActionResult ObtenerActos()
        {
            try
            {
                var actos = _context.Acto.;
                return Ok(actos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
