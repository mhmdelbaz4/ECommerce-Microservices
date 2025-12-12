using Catalog.Application.Features.Requests.Queries.Brands;
using Catalog.Application.Responses.Brands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;
public class BrandsController(IMediator _mediator): BaseApiController
{
    [HttpGet("all")]
    public async Task<ActionResult<List<BrandResponse>>> GetAllBrands()
    {
        var query = new GetAllBrandsQueryRequest();
        List<BrandResponse> brands = await _mediator.Send(query);
        return Ok(brands);

    }
}
