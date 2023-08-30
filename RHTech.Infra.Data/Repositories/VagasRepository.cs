using RhTech.Core.Domain.Entities;
using RhTech.Core.Domain.Interfaces;
using RHTech.Infra.Data;

namespace TechRecruiter.Infra.Data.Repositories
{
    public class VagasRepository : GenericRepository<Vaga>, IVagasRepository
    {
        public VagasRepository(RhTechDbContext context) : base(context) { }
    }
}
