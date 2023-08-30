using System.ComponentModel.DataAnnotations;

namespace RhTech.Core.Domain.Entities
{
    public class Candidato : BaseEntity
    {
        public string NomeCompleto { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public char Genero { get; set; }

        public string Nacionalidade { get; set; }
    }
}
