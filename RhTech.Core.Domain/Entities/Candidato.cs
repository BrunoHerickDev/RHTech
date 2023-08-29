namespace RhTech.Core.Domain.Entities
{
    public class Candidato
    {
        public int Id { get; set; }
        
        public string NomeCompleto { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public char Genero { get; set; }

        public string Nacionalidade { get; set; }

    }
}
