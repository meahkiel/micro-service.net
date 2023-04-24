using Catalog.Application.DTO;
using Catalog.Application.Interface;
using Catalog.Core.Domains;
using FluentResults;
using MediatR;

namespace Catalog.Application.Products
{
    public record GetProductQuery(string Filter,string FilterType) : IRequest<Result<ProductDTO>>;

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<ProductDTO>>
    {
        private readonly IProductRepository _productRepo;

        public GetProductQueryHandler(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Result<ProductDTO>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Product? product = null;
            
                if (request.FilterType == "name")
                {
                    product = await _productRepo.GetProductByName(request.Filter);

                }
                else
                {
                    product = await _productRepo.GetProductById(request.Filter);
                }

                return Result.Ok(new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Category = product.Category,
                    Description = product.Description,
                    Summary = product.Summary,
                    Price = product.Price,
                    ImageFile = product.ImageFile,
                });

            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            
        }
    }
}
