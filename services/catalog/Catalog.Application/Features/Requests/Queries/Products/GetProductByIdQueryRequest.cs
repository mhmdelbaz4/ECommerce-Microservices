using Catalog.Application.Responses.Products;
using MediatR;

namespace Catalog.Application.Features.Requests.Queries.Products;
public class GetProductByIdQueryRequest:IRequest<ProductResponse>
{
    public GetProductByIdQueryRequest(string id)
    {
        Id = id;
    }
    public string Id { get; set; }
}
