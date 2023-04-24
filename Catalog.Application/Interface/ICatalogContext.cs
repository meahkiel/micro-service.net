using Catalog.Core.Domains;
using MongoDB.Driver;

namespace Catalog.Application.Interface;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get;  }
}
