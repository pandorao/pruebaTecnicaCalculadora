using System.ComponentModel.DataAnnotations;

namespace Prueba.Web.Dtos
{
    public class OperationDto
    {
        [Required(ErrorMessage = "Valor A es requerido")]
        [Display(Name = "Valor A")]
        public int ValueA { get; set; }

        [Required(ErrorMessage = "Valor B es requerido")]
        [Display(Name = "Valor B")]
        public int ValueB { get; set; }
    }
}
