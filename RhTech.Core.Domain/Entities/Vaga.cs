namespace RhTech.Core.Domain.Entities
{
    public class Vaga
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Requisitos { get; set; }

        public string Localizacao { get; set; }

        public DateTime DataPublicacao { get; set; }

        public DateTime DataEncerramento { get; set; }

        public int IdEmpresa { get; set; }

        public Empresa Empresa { get; set; }
    }
}
