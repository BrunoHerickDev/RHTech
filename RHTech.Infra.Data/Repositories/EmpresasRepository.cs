using RhTech.Core.Domain.Entities;
using RhTech.Core.Domain.Interfaces;
using RHTech.Infra.Data;

namespace TechRecruiter.Infra.Data.Repositories
{
    public class EmpresasRepository : GenericRepository<Empresa>, IEmpresasRepository
    {
        public EmpresasRepository(RhTechDbContext context) : base(context) { }
    }
}
