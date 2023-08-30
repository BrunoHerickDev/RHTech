using RhTech.Core.Domain.Entities;
using RHTech.Infra.Data;

namespace TechRecruiter.Infra.Data.Repositories
{
    public class VagasRepository : GenericRepository<Vaga>
    {
        public VagasRepository(RhTechDbContext context) : base(context) { }
    }
}
