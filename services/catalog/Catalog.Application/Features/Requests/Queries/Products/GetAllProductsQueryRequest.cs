using Catalog.Application.Dtos;
using Catalog.Application.Responses;
using Catalog.Application.Responses.Products;
using MediatR;

namespace Catalog.Application.Features.Requests.Queries.Products;
public class GetAllProductsQueryRequest: IRequest<PaginationReponse<ProductResponse>>
{
    public GetAllProductsQueryRequest(PaginationSpecParams specs)
    {
        PaginationSpecParams = specs;
    }
    public PaginationSpecParams PaginationSpecParams{ get; set; }
}
