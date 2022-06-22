using System.ComponentModel.DataAnnotations;

namespace notaria.DataEntities
{
    public class EstatusEntity
    {
        public int id { get; set; }
        [StringLength(50)]
        public string? estatus { get; set; }
    }
}
