﻿namespace Modelo
{
    public class Proveedor //: BaseEntity
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "El  Nombre de la compañia es obligatorio.")]
        public string? NombreCompañia { get; set; }

    //    [Required(ErrorMessage = "El Correo es obligatorio.")]
  //      [EmailAddress(ErrorMessage = "Debe de cumplir como correo.")]
        public string? Correo { get; set; }

  //      [Required(ErrorMessage = "El Telefono es obligatorio.")]
        public string? Telefono { get; set; }

      //  [Required(ErrorMessage = "El  Estado es obligatorio.")]
    //    [Range(0, int.MaxValue, ErrorMessage = "El estado debe ser un número positivo.")]
        public bool Estado { get; set; }

    //    [Required(ErrorMessage = "La Fecha de creacion es obligatorio.")]
        public DateTime FechaCreacion { get; set; }

    }
}
