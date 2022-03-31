using System.ComponentModel.DataAnnotations;

namespace Prueba.Web.Dtos
{
    public class OperationRequestDto
    {
        [Required(ErrorMessage = "Valor A es requerido")]
        [Display(Name = "Valor A")]
        public long ValueA { get; set; }

        [Required(ErrorMessage = "Valor B es requerido")]
        [Display(Name = "Valor B")]
        public long ValueB { get; set; }
    }

    public class OperationResponseDto
    {
        public long ResultOperation { get; set; }
        public string FibonacciMessage { get; set; }
    }
}
