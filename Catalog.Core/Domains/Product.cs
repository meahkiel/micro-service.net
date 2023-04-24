using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Domains
{
    public class Product
    {

        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Product(
                       string name,
                       string description,
                       string? summary,
                       string category,
                       decimal price,
                       
                       string imageFile)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Summary = summary;
            Description = description;
            Category = category;
            Price = price;
            
            ImageFile = imageFile;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        public string? Summary { get; set; } 
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public decimal Price { get; set; }
       

        public string ImageFile { get; set; } = string.Empty;

    }
}
