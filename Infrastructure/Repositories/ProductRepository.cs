using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Common;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(INoSQLDatabaseSettings context, IConfiguration configuration)
            : base(context, configuration, NoSQLDatabaseEnum.Product.ToString())
        {

        }

        public async Task<List<Product>> GetAll(string description)
        {
            var products = await Get().Where(p => p.Description.Contains(description)).ToListAsync();

            return products;
        }
    }
}
