using Application.Common.Interfaces.NoSQLRepositories;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAll(string description);
    }
}
