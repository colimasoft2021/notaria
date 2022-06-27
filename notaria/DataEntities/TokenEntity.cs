using System.ComponentModel.DataAnnotations;

namespace notaria.DataEntities
{
    public class TokenEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string? Token { get; set; }
        [StringLength(100)]
        public string? Correo { get; set; }
        public bool? Confirmado { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaCreado { get; set; }
    }
}
