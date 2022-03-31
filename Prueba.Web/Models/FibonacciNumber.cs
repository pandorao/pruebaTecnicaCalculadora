using System.ComponentModel.DataAnnotations;

namespace Prueba.Web.Models
{
    public class FibonacciNumber
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El numero es requerido")]
        [Display(Name = "Numero")] 
        public int Number { get; set; }
    }
}
