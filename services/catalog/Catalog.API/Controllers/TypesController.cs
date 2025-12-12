using Catalog.Application.Features.Requests.Queries.Brands;
using Catalog.Application.Features.Requests.Queries.Types;
using Catalog.Application.Responses.Types;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;
public class TypesController(IMediator _mediator): BaseApiController
{
    [HttpGet("all")]
    public async Task<ActionResult<List<TypeResponse>>> GetAllTypes()
    {
        var query = new GetAllTypesQueryRequest();
        List<TypeResponse> types = await _mediator.Send(query);  
        return Ok(types);
    }
}
