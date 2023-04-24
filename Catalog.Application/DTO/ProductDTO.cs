using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.DTO
{
    public class ProductDTOContainer
    {
        public IEnumerable<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }

    public class ProductDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Summary { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public decimal Price { get; set; }


        public string ImageFile { get; set; } = string.Empty;
    }
}
