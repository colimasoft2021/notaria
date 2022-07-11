using System.ComponentModel.DataAnnotations;

namespace notaria.Models
{
    public class RolModel
    {
        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string? rolName { get; set; }
    }
}
