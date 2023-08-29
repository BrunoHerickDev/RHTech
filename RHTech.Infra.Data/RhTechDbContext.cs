using Microsoft.EntityFrameworkCore;
using RhTech.Core.Domain.Entities;

namespace RHTech.Infra.Data
{
    public class RhTechDbContext : DbContext
    {
        public RhTechDbContext(DbContextOptions options) : base(options) { }

        public RhTechDbContext() { }

        public DbSet<Candidato> Candidatos { get; set; }

        public DbSet<Vaga> Vagas { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

    }
}
