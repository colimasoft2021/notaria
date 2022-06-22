using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace notaria.DataEntities
{
    public class TramiteEntity
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


        [ForeignKey("usuarioId")]
        public virtual UserEntity UserEntity { get; set; }

        [ForeignKey("estatusId")]
        public virtual EstatusEntity EstatusEntity { get; set; }

        [ForeignKey("actoId")]
        public virtual ActoEntity ActoEntity { get; set; }
    }
}
