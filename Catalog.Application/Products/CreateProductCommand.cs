using Catalog.Application.DTO;
using Catalog.Application.Interface;
using Catalog.Core.Domains;
using FluentResults;
using MediatR;

namespace Catalog.Application.Products;

public record CreateProductCommand(ProductDTO Product) : IRequest<Result<ProductDTO>>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductDTO>>
{
    private readonly IProductRepository _productRepository;
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<Result<ProductDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = new Product(
                request.Product.Name,
                request.Product.Description,
                request.Product.Summary,
                request.Product.Category,
                request.Product.Price,
                request.Product.ImageFile);

            await _productRepository.Add(product);
            

            return Result.Ok(new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Summary = product.Summary,
                Category = product.Category,
                ImageFile = product.ImageFile,
                Price = product.Price,
            });

        }catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}
