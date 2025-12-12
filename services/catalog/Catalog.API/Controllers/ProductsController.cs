using Catalog.Application.Dtos;
using Catalog.Application.Dtos.Product;
using Catalog.Application.Features.Handlers.Queries.Products;
using Catalog.Application.Features.Requests.Commands.Products;
using Catalog.Application.Features.Requests.Queries.Products;
using Catalog.Application.Responses;
using Catalog.Application.Responses.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;
public class ProductsController(IMediator _mediater):BaseApiController
{
    [HttpGet("all")]
    public async Task<ActionResult<PaginationReponse<ProductResponse>>> GetAllProducts([FromQuery]PaginationSpecParams specs)
    {
        var query = new GetAllProductsQueryRequest(specs);
        PaginationReponse<ProductResponse> products = await _mediater.Send(query);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetProductById(string id)
    {
        var query = new GetProductByIdQueryRequest(id);
        ProductResponse product = await _mediater.Send(query);
        if (product == null)
            return BadRequest();

        return Ok(product);
    }

    [HttpGet("all/{name}")]
    public async Task<ActionResult<List<ProductResponse>>> GetProductByName(string name)
    {
        var query = new GetAllProductsByNameQueryRequest(name);
        List<ProductResponse> products = await _mediater.Send(query);

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductDto product)
    {
        var command = new CreateProductCommandRequest(product);
        await _mediater.Send(command);
        return Ok(product);
    }
}
