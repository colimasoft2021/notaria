using System.ComponentModel.DataAnnotations;

namespace notaria.DataEntities
{
    public class TipoActoEntity
    {
        public int id { get; set; }
        [StringLength(50)]
        public string? tipoActo { get; set; }
        public int? numeroDePasos { get; set; }
    }
}
