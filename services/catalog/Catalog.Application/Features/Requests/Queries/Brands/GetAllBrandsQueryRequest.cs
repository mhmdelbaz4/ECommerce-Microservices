using Catalog.Application.Responses.Brands;
using MediatR;
namespace Catalog.Application.Features.Requests.Queries.Brands;

public class GetAllBrandsQueryRequest: IRequest<List<BrandResponse>>
{
}
