//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using RhTech.Core.Domain.Entities;

//namespace RHTech.Infra.Data
//{
//    public class RhTechDbContext : DbContext
//    {
//        public RhTechDbContext(DbContextOptions options) : base(options) { }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//                .AddJsonFile("appsettings.json")
//                .Build();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("RhTechConnection"));
//        }

//        public RhTechDbContext() { }

//        public DbSet<Candidato> Candidatos { get; set; }

//        public DbSet<Vaga> Vagas { get; set; }

//        public DbSet<Empresa> Empresas { get; set; }

//    }
//}
