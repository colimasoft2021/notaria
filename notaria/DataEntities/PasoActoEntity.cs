using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace notaria.DataEntities
{
    public class PasoActoEntity
    {
        public int id { get; set; }
        public int? diasHabiles { get; set; }
        [StringLength(100)]
        public string? titulo { get; set; }
        public bool? permitirArchivo { get; set; }
        public bool? esParalelo { get; set; }
        public bool? esIndependiente { get; set; }
        public bool? campoTrasladoDominio { get; set; }
        public bool? campoRegistroPublicoPropiedad { get; set; }
        //TrasladoDominio - TD
        public bool? fechaEnviadoActivoTD { get; set; }
        public bool? deSalidaTD { get; set; }
        public bool? fechaRevisionTD { get; set; }
        public bool? deRechazoTD { get; set; }
        public bool? fechaRechazoTD { get; set; }
        public bool? motivoRechazoTD { get; set; }
        public bool? fechaRechazoEnviadoTD { get; set; }
        public bool? fechaRechazoRevisionTD { get; set; }
        //RegistroPublicoPropiedad - RPP
        public bool? positivoRPP { get; set; }
        public bool? fechaPositivoFirmaRPP { get; set; }
        public bool? fechaPositivoPagoRPP { get; set; }
        public bool? fechaPositivoSelloRPP { get; set; }
        public bool? calificacionPositivoRPP { get; set; }
        public bool? rechazoRPP { get; set; }
        public bool? fechaReingresoRechazoRPP { get; set; }
        public bool? motivoRechazoRPP { get; set; }
        //Foreing Key
        public int? actoId { get; set; }
        [ForeignKey("actoId")]
        public virtual ActoEntity ActoEntity { get; set; }
    }
}
