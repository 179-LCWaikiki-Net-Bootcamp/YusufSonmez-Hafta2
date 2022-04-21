using System.Linq;
using System.Threading.Tasks;
using ProductCatalogueWebapi;
using ProductCatalogueWebapi.Entities.GenericRepository;

public class GenericRepository<TEntity>: IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ProjectDbContext _dbContext;

    public GenericRepository(ProjectDbContext _dbContext, ProjectDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public Task Create(TEntity entity)
    {
        throw new System.NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new System.NotImplementedException();
    }

    public IQueryable<TEntity> GetAll()
    {
        throw new System.NotImplementedException();
    }

    public Task<TEntity> GetByID(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task Update(int id, TEntity entity)
    {
        throw new System.NotImplementedException();
    }
}