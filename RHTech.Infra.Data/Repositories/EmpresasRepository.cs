using RhTech.Core.Domain.Entities;
using RHTech.Infra.Data;

namespace TechRecruiter.Infra.Data.Repositories
{
    public class EmpresasRepository : GenericRepository<Empresa>
    {
        public EmpresasRepository(RhTechDbContext context) : base(context) { }
    }
}
