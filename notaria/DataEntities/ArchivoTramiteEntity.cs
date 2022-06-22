using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace notaria.DataEntities
{
    public class ArchivoTramiteEntity
    {
        public int id { get; set; }
        [StringLength(250)]
        public string? urlArchivo { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaActualizacion { get; set; }
        //Foreing key
        public int? tramiteId { get; set; }
        public int? usuarioCreoId { get; set; }
        public int? usuarioModificoId { get; set; }

        [ForeignKey("tramiteId")]
        public virtual TramiteEntity TramiteEntity { get; set; }

        [ForeignKey("usuarioCreoId")]
        public virtual UserEntity UserEntity { get; set; }
    }
}
