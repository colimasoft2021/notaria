using System.ComponentModel.DataAnnotations;

namespace notaria.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        public string correo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string? clave { get; set; }
    }
}
