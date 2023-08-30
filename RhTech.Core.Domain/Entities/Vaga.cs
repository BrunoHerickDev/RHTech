using System.ComponentModel.DataAnnotations;

namespace RhTech.Core.Domain.Entities
{
    public class Vaga : BaseEntity
    {
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome Fantasia")]
        [StringLength(100, MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")]
        [StringLength(500, MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Requisitos")]
        [StringLength(500, MinimumLength = 2)]
        public string Requisitos { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Localização")]
        [StringLength(100, MinimumLength = 2)]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data de Publicação")]
        public DateTime DataPublicacao { get; set; }

        [Display(Name = "Data de Encerramento")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataEncerramento { get; set; }


        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }

        public Empresa Empresa { get; set; }
    }
}
