using System.Linq;
using System.Threading.Tasks;

using ProductCatalogueWebapi.Entities.GenericRepository;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetAll();
    Task<TEntity> GetByID(int id);
    Task Create(TEntity entity);
    Task Update(int id, TEntity entity);
    Task Delete(int id);
}