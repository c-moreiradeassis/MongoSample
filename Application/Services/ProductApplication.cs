using Application.Common.Interfaces;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _repository;

        public ProductApplication(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateProductAsync()
        {
            Product product = new Product() { Id = Guid.NewGuid().ToString(), Description = "Test", Price = 150.0m };

            await _repository.InsertAsync(product);
        }

        public async Task<List<Product>> GetAllAsync(string description)
        {
            var products = await _repository.GetAll(description);

            return products;
        }
    }
}
