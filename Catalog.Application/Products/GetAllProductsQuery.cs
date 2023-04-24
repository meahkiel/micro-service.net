using Catalog.Application.DTO;
using Catalog.Application.Interface;
using FluentResults;
using MediatR;

namespace Catalog.Application.Products
{
    public record GetAllProductsQuery() : IRequest<Result<ProductDTOContainer>>;

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, Result<ProductDTOContainer>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<ProductDTOContainer>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAll();

                return Result.Ok(new ProductDTOContainer
                {
                    Products = products.Select(c => new ProductDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Category = c.Category,
                        Description = c.Description,
                        Summary = c.Summary,
                        Price = c.Price,
                        ImageFile = c.ImageFile,
                    })
                });

            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            
        }
    }
}
