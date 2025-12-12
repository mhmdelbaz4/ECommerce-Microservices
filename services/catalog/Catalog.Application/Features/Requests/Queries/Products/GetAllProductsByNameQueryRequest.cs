using Catalog.Application.Responses.Products;
using MediatR;

namespace Catalog.Application.Features.Requests.Queries.Products;
public class GetAllProductsByNameQueryRequest : IRequest<List<ProductResponse>>
{
    public GetAllProductsByNameQueryRequest(string name)
    {
        Name = name;
    }
    public string Name { get; set; }

}
