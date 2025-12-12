using Catalog.Application.Responses.Products;
using MediatR;

namespace Catalog.Application.Features.Requests.Queries.Products;
public class GetAllProductsByBrandNameQueryRequest : IRequest<List<ProductResponse>>
{
    public GetAllProductsByBrandNameQueryRequest(string brandName)
    {
        BrandName = brandName;
    }
    public string BrandName { get; set; }
}
