using System.ComponentModel.DataAnnotations;

namespace notaria.DataEntities
{
    public class RolEntity
    {
        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string? rolName { get; set; }
    } 
}
