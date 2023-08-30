using RhTech.Core.Domain.Entities;
using RHTech.Infra.Data;

namespace TechRecruiter.Infra.Data.Repositories
{
    public class CandidatosRepository : GenericRepository<Candidato>
    {
        public CandidatosRepository(RhTechDbContext context) : base(context) { }
    }
}
