using Catalog.Application.Interface;
using Catalog.Core.Domains;
using Catalog.Core.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IMongoCollection<Product> _products;
        public CatalogContext(IOptions<ConnectionSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.Host);
            var database = mongoClient.GetDatabase(options.Value.DatabaseName);
            _products = database.GetCollection<Product>(options.Value.CollectionName);

        }


        public IMongoCollection<Product> Products => _products;
    }
}
