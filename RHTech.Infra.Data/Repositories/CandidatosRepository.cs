using RhTech.Core.Domain.Entities;
using RhTech.Core.Domain.Interfaces;
using RHTech.Infra.Data;

namespace TechRecruiter.Infra.Data.Repositories
{
    public class CandidatosRepository : GenericRepository<Candidato>, ICandidatosRepository
    {
        public CandidatosRepository(RhTechDbContext context) : base(context) { }
    }
}
