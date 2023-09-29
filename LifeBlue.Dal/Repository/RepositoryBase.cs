using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeBlue.Dal.Contexts;
using LifeBlue.Dal.DTO;

namespace LifeBlue.Dal.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        protected LifeBlueContext _context { get; set; }

        public RepositoryBase(LifeBlueContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(int id) => 
            await _context.Set<TEntity>().FindAsync(id);

        public async Task Add(TEntity entity) =>
            await _context.Set<TEntity>().AddAsync(entity);
        
    }
}
