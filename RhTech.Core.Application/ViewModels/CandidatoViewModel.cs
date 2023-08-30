using System.ComponentModel.DataAnnotations;

namespace RhTech.Core.Application.ViewModels
{
    public class CandidatoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome Completo")]
        [StringLength(100, MinimumLength = 4)]
        public string NomeCompleto { get; set; }


        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Cpf")]
        [StringLength(14, MinimumLength = 14)]
        public string Cpf { get; set; }


        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Gênero")]
        public char Genero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nacionalidade")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string Nacionalidade { get; set; }
    }
}
