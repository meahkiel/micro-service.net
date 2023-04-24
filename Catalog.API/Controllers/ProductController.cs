using Catalog.Application.DTO;
using Catalog.Application.Interface;
using Catalog.Application.Products;
using Catalog.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICatalogContext _catalogContext;

        public ProductController(IMediator mediator,ICatalogContext catalogContext)
        {
            _mediator = mediator;
            _catalogContext = catalogContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());

            if(!result.IsSuccess)
                return BadRequest(result.Errors[0].ToString());

            return Ok(result.ValueOrDefault);

        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]ProductDTO product)
        {
            var result = await _mediator.Send(new CreateProductCommand(product));

            if (!result.IsSuccess)
                return BadRequest(result.Errors[0].ToString());

            return Ok(result.ValueOrDefault);
        }

        [HttpPost("seed")]
        public async Task<IActionResult> Seed()
        {  
            await CatalogSeed.Seed(_catalogContext);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery]GetProductQuery query)
        {
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Errors[0].ToString());

            return Ok(result.ValueOrDefault);
        }
    }
}
