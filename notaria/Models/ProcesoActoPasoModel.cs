namespace notaria.Models
{
    public class ProcesoActoPasoModel
    {
        public int id { get; set; }
        public int? diasHabiles { get; set; }
        public int? numeroDePasos { get; set; }
        public int? tipoActoId { get; set; }
        public List<PasoActoModel> PasosActoModels { get; set; }
    }

    public class PasoActoModel
    {
        public int id { get; set; }
        public int? diasHabiles { get; set; }
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

        //Foreing key
        public int? actoId { get; set; }
    }
}
