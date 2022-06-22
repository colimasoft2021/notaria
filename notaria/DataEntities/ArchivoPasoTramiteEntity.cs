using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace notaria.DataEntities
{
    public class ArchivoPasoTramiteEntity
    {
        public int id { get; set; }
        [StringLength(250)]
        public string? urlArchivo { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaActualizacion { get; set; }
        //Foreing key
        public int? pasoTramiteId { get; set; }
        public int? usuarioCreoId { get; set; }
        public int? usuarioModificoId { get; set; }


        [ForeignKey("pasoTramiteId")]
        public virtual TramitePasoEntity TramitePasoEntity { get; set; }

        [ForeignKey("usuarioCreoId")]
        public virtual UserEntity UserEntity { get; set; }

    }
}
