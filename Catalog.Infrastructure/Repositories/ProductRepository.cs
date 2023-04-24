using Catalog.Application.Interface;
using Catalog.Core.Domains;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;
        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }


        public async Task Add(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _catalogContext
                            .Products
                            .Find(p => true)
                            .ToListAsync();
                        
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await _catalogContext.Products.Find(p => p.Id == productId)
                            .FirstOrDefaultAsync();
        }

        public async  Task<Product> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name,name);
            return await _catalogContext.Products.Find(filter)
                .FirstOrDefaultAsync();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
