using System.ComponentModel.DataAnnotations;

namespace notaria.Models
{
    public class UserModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string? apellido { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        public string correo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string? clave { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public bool? Activo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public bool? modificar { get; set; }
        public int? rolId { get; set; }
    }
}
