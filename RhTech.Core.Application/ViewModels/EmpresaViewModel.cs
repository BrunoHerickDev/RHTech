using System.ComponentModel.DataAnnotations;

namespace RhTech.Core.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Cnpj")]
        [StringLength(18, MinimumLength = 18)]
        public string Cnpj { get; set; }


        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome Fantasia")]
        [StringLength(100, MinimumLength = 2)]
        public string NomeFantasia { get; set; }
    }
}
