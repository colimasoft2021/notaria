using System.ComponentModel.DataAnnotations.Schema;

namespace notaria.DataEntities
{
    public class ActoEntity
    {
        public int id { get; set; }
        public int? diasHabiles { get; set; }
        public int? numeroDePasos { get; set; }
        //Foreing key
        public int? tipoActoId { get; set; }
        [ForeignKey("tipoActoId")]
        public virtual TipoActoEntity TipoActoEntity { get; set; }
    }
}
