﻿namespace notaria.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string correo { get; set; }
        public string? clave { get; set; }
        public bool? Activo { get; set; }
        public bool? modificar { get; set; }
        public int? rolId { get; set; }
    }
}
