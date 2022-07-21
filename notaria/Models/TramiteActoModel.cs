﻿using System.ComponentModel.DataAnnotations;

namespace notaria.Models
{
    public class TramiteActoModel
    {
        public int id { get; set; }
        public string? numeroDeEscritura { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaEscritura { get; set; }
        public DateTime? fechaFirma { get; set; }
        [StringLength(100)]
        public string? parteA { get; set; }
        [StringLength(100)]
        public string? parteB { get; set; }
        public int? diasHabiles { get; set; }
        //Foreing Key
        public int? usuarioId { get; set; }
        public int? estatusId { get; set; }
        public int? actoId { get; set; }

        public List<PasosTramiteModel>? PasosTramite { get; set; }
    }

    public class PasosTramiteModel
    {
        public int id { get; set; }
        public int? diasHabiles { get; set; }
        [StringLength(100)]
        public string titulo { get; set; }
        public DateTime? fechaRealizado { get; set; }
        public DateTime? fechaVencimiento { get; set; }
        public int? diasRetraso { get; set; }
        public bool? permitirArchivo { get; set; }
        public bool? esParalelo { get; set; }
        public bool? campoTrasladoDominio { get; set; }
        public bool? campoRegistroPublicoPropiedad { get; set; }
        //TrasladoDominio - TD
        public bool? fechaEnviadoActivoTD { get; set; }
        public DateTime? fechaEnviadoTD { get; set; }
        public bool? fechaRevisionActivoTD { get; set; }
        public DateTime? fechaRevisionTD { get; set; }
        public bool? deSalidaActivoTD { get; set; }
        public bool? fechaDeSalidaActivoTD { get; set; }
        public DateTime? fechaDeSalidaTD { get; set; }
        public bool? deRechazoActivoTD { get; set; }
        public bool? fechaRechazoActivoTD { get; set; }
        public DateTime? fechaRechazoTD { get; set; }
        public bool? motivoRechazoActivoTD { get; set; }
        public string? motivoReachazoTD { get; set; }
        public bool? fechaRechazoEnviadoActivoTD { get; set; }
        public DateTime? fechaRechazoEnviadoTD { get; set; }
        public bool? fechaRechazoRevisionActivoTD { get; set; }
        public DateTime? fechaRechazoRevisionTD { get; set; }
        //RegistroPublicoPropiedad - RPP
        public bool? positivoActivoRPP { get; set; }
        public bool? fechaPositivoFirmaActivoRPP { get; set; }
        public DateTime? fechaPositivoFirmaRPP { get; set; }
        public bool? fechaPositivoPagoActivoRPP { get; set; }
        public DateTime? fechaPositivoPagoRPP { get; set; }
        public bool? fechaPositivoSelloActivoRPP { get; set; }
        public DateTime? fechaPositivoSelloRPP { get; set; }
        public bool? calificacionPositivoActivoRPP { get; set; }
        public string? calificacionPositivoRPP { get; set; }
        public bool? rechazoActivoRPP { get; set; }
        public bool? fechaReingresoRechazoActivoRPP { get; set; }
        public DateTime? fechaReingresoRechazoRPP { get; set; }
        public bool? motivoRechazoActivoRPP { get; set; }
        public string? motivoRechazoRPP { get; set; }
        //Foreing key(s)
        public int? estatusId { get; set; }
        public int? usuarioId { get; set; }
        public int? tramiteId { get; set; }
    }
}
