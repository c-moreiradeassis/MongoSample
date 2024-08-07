using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductApplication
    {
        Task<List<Product>> GetAllAsync(string description);
        Task CreateProductAsync();
    }
}
