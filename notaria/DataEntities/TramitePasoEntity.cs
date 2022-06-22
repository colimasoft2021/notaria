using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace notaria.DataEntities
{
    public class TramitePasoEntity
    {
        [Key]
        public int id { get; set; }
        public int? diasHabiles { get; set; }
        [StringLength(100)]
        public string titulo { get; set; }
        public DateTime? fechaRealizado { get; set; }
        public DateTime? fechaVencimiento { get; set; }
        public int? diasRetraso { get; set; }
        //traslado_dominio  -- TrasladoDominio  - TD
        public DateTime? fechaEnviadoActivoTD { get; set; }
        public DateTime? fechaDeSalidaTD { get; set; }
        public DateTime? fechaRevisionTD { get; set; }
        public bool? rechazoTD { get; set; }
        public DateTime? fechaRechazoTD { get; set; }
        [StringLength(250)]
        public string motivoRechazoTD { get; set; }
        public DateTime? fechaRechazoEnviadoTD { get; set; }
        public DateTime? fechaRechazoRevisionTD { get; set; }
        //registro_publico_propiedad  - RPP
        public bool? positivoRPP { get; set; }
        public DateTime? fechaPositivoFirmaRPP { get; set; }
        public DateTime? fechaPositivoPagoRPP { get; set; }
        public DateTime? fechaPositivoSelloRPP { get; set; }
        [StringLength(150)]
        public string calificacionPositivoRPP { get; set; }
        public bool? rechazoRPP { get; set; }
        public DateTime? fechaReingresoRechazoRPP { get; set; }
        [StringLength(250)]
        public string motivoRechazoRPP { get; set; }
        //Foreing key(s)
        public int? pasoActoId { get; set; }
        public int? estatusId { get; set; }
        public int? usuarioId { get; set; }
        public int? tramiteId { get; set; }


        [ForeignKey("pasoActoId")]
        public virtual PasoActoEntity PasoActoEntity { get; set; }

        [ForeignKey("estatusId")]
        public virtual EstatusEntity EstatusEntity { get; set; }

        [ForeignKey("usuarioId")]
        public virtual UserEntity UserEntity { get; set; }

        [ForeignKey("tramiteId")]
        public virtual TramiteEntity TramiteEntity { get; set; }

    }
}
