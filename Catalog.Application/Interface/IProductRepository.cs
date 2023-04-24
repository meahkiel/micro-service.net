using Catalog.Core.Domains;

namespace Catalog.Application.Interface
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Update(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProductById(string productId);
        Task<Product> GetProductByName(string name);
    }
}
