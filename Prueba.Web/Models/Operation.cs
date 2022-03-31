using System.ComponentModel.DataAnnotations;

namespace Prueba.Web.Models
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Valor A es requerido")]
        [Display(Name = "Valor A")]
        public long ValueA { get; set; }

        [Required(ErrorMessage = "Valor B es requerido")]
        [Display(Name = "Valor B")]
        public long ValueB { get; set; }

        [Required(ErrorMessage = "Resultado es requerido")]
        [Display(Name = "Resultado")]
        public long Result { get; set; }
    }
}
