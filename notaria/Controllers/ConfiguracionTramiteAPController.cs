using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notaria.DataContext;
using notaria.DataEntities;
using notaria.Models;

namespace notaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionTramiteAPController : ControllerBase
    {
        private readonly NotariaContext _context;

        public ConfiguracionTramiteAPController(NotariaContext context)
        {
            _context = context;
        }

        [HttpGet("/api/Acto/GetActoPasos")]
        public IActionResult GetActoPasos(int id)
        {
            try
            {
                var ActoPasosConfig = _context.Acto.Where(a => a.id == id)
                    .Include(a => a.TipoActoEntity)
                    .Include(a => a.PasoActoEntity).AsNoTracking().ToList();

                return Ok(ActoPasosConfig);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/Acto/CreateActoPasos")]
        public IActionResult CrearActoPaso([FromBody] ProcesoActoPasoModel model)
        {
            var message = new { status = "", message = "" };
            IActionResult ret = null;

            Console.WriteLine(model);

            try
            {
                var acto = new ActoEntity();
                acto.tipoActoId = model.tipoActoId;
                acto.diasHabiles = model.diasHabiles;
                acto.numeroDePasos = model.numeroDePasos;
                _context.Acto.Add(acto);
                _context.SaveChanges();
                try
                {
                    foreach (var paso in model.PasosActoModels)
                    {
                        var valPaso = new PasoActoEntity();
                        valPaso.diasHabiles = paso.diasHabiles;
                        valPaso.titulo = paso.titulo;
                        valPaso.permitirArchivo = paso.permitirArchivo;
                        valPaso.esParalelo = paso.esParalelo;
                        valPaso.esIndependiente = paso.esIndependiente;
                        valPaso.campoTrasladoDominio = paso.campoTrasladoDominio;
                        valPaso.campoRegistroPublicoPropiedad = paso.campoRegistroPublicoPropiedad;
                        //TrasladoDominio - TD
                        valPaso.fechaEnviadoActivoTD = paso.fechaEnviadoActivoTD;
                        valPaso.deSalidaTD = paso.deSalidaTD;
                        valPaso.fechaRevisionTD = paso.fechaRevisionTD;
                        valPaso.deRechazoTD = paso.deRechazoTD;
                        valPaso.fechaRechazoTD = paso.fechaRechazoTD;
                        valPaso.motivoRechazoTD = paso.motivoRechazoTD;
                        valPaso.fechaRechazoEnviadoTD = paso.fechaRechazoEnviadoTD;
                        valPaso.fechaRechazoRevisionTD = paso.fechaRechazoRevisionTD;
                        //RegistroPublicoPropiedad - RPP
                        valPaso.positivoRPP = paso.positivoRPP;
                        valPaso.fechaPositivoFirmaRPP = paso.fechaPositivoFirmaRPP;
                        valPaso.fechaPositivoPagoRPP = paso.fechaPositivoPagoRPP;
                        valPaso.fechaPositivoSelloRPP = paso.fechaPositivoSelloRPP;
                        valPaso.calificacionPositivoRPP = paso.calificacionPositivoRPP;
                        valPaso.rechazoRPP = paso.rechazoRPP;
                        valPaso.fechaReingresoRechazoRPP = paso.fechaReingresoRechazoRPP;
                        valPaso.motivoRechazoRPP = paso.motivoRechazoRPP;

                        valPaso.actoId = acto.id;
                        _context.PasoActo.Add(valPaso);
                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                }

                message = new { status = "OK", message = "Datos registrados" };
                ret = StatusCode(StatusCodes.Status201Created, message);

                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message = new { status = "Errpr", message = ex.Message };
                ret = StatusCode(StatusCodes.Status500InternalServerError, message);
                return ret;
            }
        }


        [HttpPut("/api/Acto/UpdateActoPasos")]
        public IActionResult ModificarActoPAso([FromBody] ProcesoActoPasoModel model)
        {
            try
            {
                var acto = new ActoEntity();
                acto.id = model.id;
                acto.tipoActoId = model.tipoActoId;
                acto.diasHabiles = model.diasHabiles;
                acto.numeroDePasos = model.numeroDePasos;
                _context.Acto.Update(acto);
                _context.SaveChanges();

                try
                {
                    foreach (var paso in model.PasosActoModels)
                    {
                        var valPaso = new PasoActoEntity();
                        valPaso.id = paso.id;
                        valPaso.diasHabiles = paso.diasHabiles;
                        valPaso.titulo = paso.titulo;
                        valPaso.permitirArchivo = paso.permitirArchivo;
                        valPaso.esParalelo = paso.esParalelo;
                        valPaso.esIndependiente = paso.esIndependiente;
                        valPaso.campoTrasladoDominio = paso.campoTrasladoDominio;
                        valPaso.campoRegistroPublicoPropiedad = paso.campoRegistroPublicoPropiedad;
                        //TrasladoDominio - TD
                        valPaso.fechaEnviadoActivoTD = paso.fechaEnviadoActivoTD;
                        valPaso.deSalidaTD = paso.deSalidaTD;
                        valPaso.fechaRevisionTD = paso.fechaRevisionTD;
                        valPaso.deRechazoTD = paso.deRechazoTD;
                        valPaso.fechaRechazoTD = paso.fechaRechazoTD;
                        valPaso.motivoRechazoTD = paso.motivoRechazoTD;
                        valPaso.fechaRechazoEnviadoTD = paso.fechaRechazoEnviadoTD;
                        valPaso.fechaRechazoRevisionTD = paso.fechaRechazoRevisionTD;
                        //RegistroPublicoPropiedad - RPP
                        valPaso.positivoRPP = paso.positivoRPP;
                        valPaso.fechaPositivoFirmaRPP = paso.fechaPositivoFirmaRPP;
                        valPaso.fechaPositivoPagoRPP = paso.fechaPositivoPagoRPP;
                        valPaso.fechaPositivoSelloRPP = paso.fechaPositivoSelloRPP;
                        valPaso.calificacionPositivoRPP = paso.calificacionPositivoRPP;
                        valPaso.rechazoRPP = paso.rechazoRPP;
                        valPaso.fechaReingresoRechazoRPP = paso.fechaReingresoRechazoRPP;
                        valPaso.motivoRechazoRPP = paso.motivoRechazoRPP;

                        valPaso.actoId = acto.id;
                        _context.PasoActo.Update(valPaso);
                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                }

                var ActoPasosConfig = _context.Acto.Where(a => a.id == model.id)
                    .Include(a => a.TipoActoEntity)
                    .Include(a => a.PasoActoEntity).AsNoTracking().ToList();

                var message = new { status = "Ok", message = "Datos Actualizados", data = ActoPasosConfig };

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
