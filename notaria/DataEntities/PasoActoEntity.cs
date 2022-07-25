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
        public bool? campoTrasladoDominio { get; set; }
        public bool? campoRegistroPublicoPropiedad { get; set; }
        //TrasladoDominio - TD
        public bool? fechaEnviadoActivoTD { get; set; }
        public bool? fechaRevisionActivoTD { get; set; }
        public bool? deSalidaActivoTD { get; set; }
        public bool? fechaDeSalidaActivoTD { get; set; }
        public bool? deRechazoActivoTD { get; set; }
        public bool? fechaRechazoActivoTD { get; set; }
        public bool? motivoRechazoActivoTD { get; set; }
        public bool? fechaRechazoEnviadoActivoTD { get; set; }
        public bool? fechaRechazoRevisionActivoTD { get; set; }
        //RegistroPublicoPropiedad - RPP
        public bool? positivoActivoRPP { get; set; }
        public bool? fechaPositivoFirmaActivoRPP { get; set; }
        public bool? fechaPositivoPagoActivoRPP { get; set; }
        public bool? fechaPositivoSelloActivoRPP { get; set; }
        public bool? calificacionPositivoActivoRPP { get; set; }
        public bool? rechazoActivoRPP { get; set; }
        public bool? fechaReingresoRechazoActivoRPP { get; set; }
        public bool? motivoRechazoActivoRPP { get; set; }
        //Foreing Key
        public int? actoId { get; set; }
        [ForeignKey("actoId")]
        public virtual ActoEntity ActoEntity { get; set; }
    }
}
