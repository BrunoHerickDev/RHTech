using Microsoft.EntityFrameworkCore;
using RhTech.Core.Domain.Entities;
using RhTech.Core.Domain.Interfaces;
using RHTech.Infra.Data;

namespace TechRecruiter.Infra.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly RhTechDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(RhTechDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> ObterLista()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> ObterPorId(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<T> Cadastrar(T entity)
        {
            if (entity == null) throw new ArgumentNullException("O objeto não pode ser nulo ou vazio.");

            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Alterar(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public virtual async Task Remover(T entity)
        {
            if (entity == null) throw new ArgumentNullException("Não foi possivel localizar o objeto");

            _context.Entry(entity).State = EntityState.Deleted;

            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public virtual DbSet<T> DbSet()
        {
            return _dbSet;
        }
    }
}
