using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Categoria
    {

        public int Id { get; set; }
       // [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
    public string? Descripcion { get; set; }

      //  [Required(ErrorMessage = "El campo Estado es obligatorio.")]
     //   [Range(0, int.MaxValue, ErrorMessage = "El Estado debe ser un número positivo.")]
        public bool Estado { get; set; }
     //   [Required(ErrorMessage = "El campo FechaCrecion es obligatorio.")]
        public DateTime FechaCreacion { get; set; }
    }
}