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
    public class TramiteController : ControllerBase
    {
        private readonly NotariaContext _context;

        public TramiteController(NotariaContext context)
        {
            _context = context;
        }

        [HttpPost("/api/Tramite/CreateTramite")]
        public IActionResult CrearTramite([FromBody] TramiteActoModel model)
        {
            var message = new { status = "", message = "", data = "" };
            IActionResult ret = null;

            try
            {
                var acto = _context.Acto.Where(a => a.id == model.actoId).FirstOrDefault();
                var tramite = new TramiteEntity();
                tramite.numeroDeEscritura = model.numeroDeEscritura;
                tramite.fechaCreacion = DateTime.Now;
                //tramite.fechaEscritura = model.fechaEscritura;
                //tramite.fechaFirma = model.fechaFirma;
                tramite.parteA = model.parteA;
                tramite.parteB = model.parteB;
                tramite.diasHabiles = acto.diasHabiles;
                tramite.usuarioId = model.usuarioId;
                tramite.estatusId = 1;
                tramite.actoId = model.actoId;
                _context.Tramite.Add(tramite);
                _context.SaveChanges();

                //obtener los pasos del actoId e insertarlos en el tramite

                var pasos = _context.PasoActo.Where(a => a.id == model.actoId).ToList();

                foreach (var paso in pasos)
                {
                    var pasoTramite = new TramitePasoEntity();
                    pasoTramite.tramiteId = tramite.id;
                    pasoTramite.estatusId = 1;
                    pasoTramite.usuarioId = model.usuarioId;
                    pasoTramite.diasHabiles = paso.diasHabiles;
                    pasoTramite.titulo = paso.titulo;
                    pasoTramite.permitirArchivo = paso.permitirArchivo;
                    pasoTramite.esParalelo = paso.esParalelo;
                    pasoTramite.campoTrasladoDominio = paso.campoTrasladoDominio;
                    pasoTramite.campoRegistroPublicoPropiedad = paso.campoRegistroPublicoPropiedad;
                    //TrasladoDominio - TD
                    pasoTramite.fechaEnviadoActivoTD = paso.fechaEnviadoActivoTD;
                    pasoTramite.fechaRevisionActivoTD = paso.fechaRevisionActivoTD;
                    pasoTramite.deSalidaActivoTD = paso.deSalidaActivoTD;
                    pasoTramite.fechaDeSalidaActivoTD = paso.fechaDeSalidaActivoTD;
                    pasoTramite.deRechazoActivoTD = paso.deRechazoActivoTD;
                    pasoTramite.fechaRechazoActivoTD = paso.fechaRechazoActivoTD;
                    pasoTramite.motivoRechazoActivoTD = paso.motivoRechazoActivoTD;
                    pasoTramite.fechaRechazoEnviadoActivoTD = paso.fechaRechazoEnviadoActivoTD;
                    pasoTramite.fechaRechazoRevisionActivoTD = paso.fechaRechazoRevisionActivoTD;
                    //RegistroPublicoPropiedad - RPP
                    pasoTramite.positivoActivoRPP = paso.positivoActivoRPP;
                    pasoTramite.fechaPositivoFirmaActivoRPP = paso.fechaPositivoFirmaActivoRPP;
                    pasoTramite.fechaPositivoPagoActivoRPP = paso.fechaPositivoPagoActivoRPP;
                    pasoTramite.fechaPositivoSelloActivoRPP = paso.fechaPositivoSelloActivoRPP;
                    pasoTramite.calificacionPositivoActivoRPP = paso.calificacionPositivoActivoRPP;
                    pasoTramite.rechazoActivoRPP = paso.rechazoActivoRPP;
                    pasoTramite.fechaReingresoRechazoActivoRPP = paso.fechaReingresoRechazoActivoRPP;
                    pasoTramite.motivoRechazoActivoRPP = paso.motivoRechazoActivoRPP;

                    _context.TramitePaso.Add(pasoTramite);
                    _context.SaveChanges(true);
                }

                message = new { status = "Ok", message = "El tramite se ha creado correctamente", data = tramite.id.ToString() };
                ret = StatusCode(StatusCodes.Status201Created, message);

                return ret;
            }
            catch (Exception ex)
            {
                message = new { status = "Error", message = ex.Message, data = "" };
                ret = StatusCode(StatusCodes.Status500InternalServerError, message);
                return ret;
            }
        }

        [HttpGet("/api/tramite/GetTramite")]
        public IActionResult obtenerTramite(int id)
        {
            var message = new { status = "", message = "", data = "" };
            IActionResult ret = null;

            try
            {

                var dataTramite = _context.Tramite.Where(t => t.id == id)
                    .Include(t => t.PasosTramite)
                    .ToList();

                ret = StatusCode(StatusCodes.Status200OK, dataTramite);

                return ret;
            }
            catch (Exception ex)
            {
                message = new { status = "Error", message = ex.Message, data = "" };
                ret = StatusCode(StatusCodes.Status500InternalServerError, message);
                return ret;
            }
        }

        [HttpPut("/api/Tramite/UpdateTramite")]
        public IActionResult ActualizarTramite([FromBody] TramiteActoModel model)
        {
            var message = new { status = "", message = "", data = "" };
            IActionResult ret = null;

            try
            {
                var tramite = new TramiteEntity();
                tramite.id = model.id;
                tramite.numeroDeEscritura = model.numeroDeEscritura;
                //tramite.fechaCreacion = model.fechaCreacion;
                tramite.fechaEscritura = model.fechaEscritura;
                tramite.fechaEscritura = model.fechaEscritura;
                tramite.parteA = model.parteA;
                tramite.parteB = model.parteB;
                //tramite.diasHabiles = model.diasHabiles;
                tramite.usuarioId = model.usuarioId;
                tramite.estatusId = model.estatusId;
                //tramite.actoId = model.actoId;
                _context.Tramite.Update(tramite);
                _context.SaveChanges();

                foreach (var paso in model.PasosTramite)
                {
                    var pasoTramite = new TramitePasoEntity();
                    pasoTramite.id = paso.id;
                    //pasoTramite.diasHabiles = paso.diasHabiles;
                    //pasoTramite.titulo = paso.titulo;
                    pasoTramite.fechaRealizado = paso.fechaRealizado;
                    pasoTramite.fechaVencimiento = paso.fechaVencimiento;
                    pasoTramite.diasRetraso = paso.diasRetraso;

                    if (paso.campoTrasladoDominio == true)
                    {
                        pasoTramite.fechaEnviadoTD = paso.fechaEnviadoTD;
                        pasoTramite.fechaRevisionTD = paso.fechaRevisionTD;
                        pasoTramite.fechaDeSalidaTD = paso.fechaDeSalidaTD;
                        pasoTramite.deRechazoActivoTD = paso.deRechazoActivoTD;
                        pasoTramite.fechaRechazoTD = paso.fechaRechazoTD;
                        pasoTramite.motivoReachazoTD = paso.motivoReachazoTD;
                        pasoTramite.fechaRechazoEnviadoTD = paso.fechaRechazoEnviadoTD;
                        pasoTramite.fechaRechazoRevisionTD = paso.fechaRechazoRevisionTD;
                    }

                    if (paso.campoRegistroPublicoPropiedad == true)
                    {
                        pasoTramite.positivoActivoRPP = paso.positivoActivoRPP;
                        pasoTramite.fechaPositivoFirmaRPP = paso.fechaPositivoFirmaRPP;
                        pasoTramite.fechaPositivoPagoRPP = paso.fechaPositivoPagoRPP;
                        pasoTramite.fechaPositivoSelloRPP = paso.fechaPositivoSelloRPP;
                        pasoTramite.calificacionPositivoRPP = paso.calificacionPositivoRPP;
                        pasoTramite.rechazoActivoRPP = paso.rechazoActivoRPP;
                        pasoTramite.fechaReingresoRechazoRPP = paso.fechaReingresoRechazoRPP;
                        pasoTramite.motivoRechazoRPP = paso.motivoRechazoRPP;
                    }

                    _context.TramitePaso.Update(pasoTramite);
                    _context.SaveChanges(true);
                }

                var dataTramite = _context.Tramite.Where(t => t.id == tramite.id)
                    .Include(t => t.PasosTramite)
                    .ToList();
                ret = StatusCode(StatusCodes.Status201Created, dataTramite);

                return ret;
            }
            catch (Exception ex)
            {
                message = new { status = "Error", message = ex.Message, data = "" };
                ret = StatusCode(StatusCodes.Status500InternalServerError, message);
                return ret;
            }
        }
    }
}
