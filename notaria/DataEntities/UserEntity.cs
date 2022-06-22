using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace notaria.DataEntities
{
    public class UserEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string? nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string? apellido { get; set; }
        [Required(ErrorMessage ="Intetanta mas tarde o reportalo al encargado de sistemas")]
        [StringLength(100)]
        public string correo { get; set; }
        [Required(ErrorMessage = "Intetanta mas tarde o reportalo al encargado de sistemas")]
        [StringLength(int.MaxValue)]
        public string? clave { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public bool? modificar { get; set; }

        public int? rolId { get; set; }
        //[ForeignKey("RolEntity")]

        ////Objeto que representa la clave externa.

        [ForeignKey("rolId")]
        public virtual RolEntity RolEntity { get; set; }
    }
}
