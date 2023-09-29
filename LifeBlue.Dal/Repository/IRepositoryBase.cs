using System.Threading.Tasks;

namespace LifeBlue.Dal.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        Task<TEntity> Get(int id);
        Task Add(TEntity entity);
        //In the future can add other methods, but don't need them yet
    }
}
