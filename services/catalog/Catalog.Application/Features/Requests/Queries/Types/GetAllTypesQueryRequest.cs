using Catalog.Application.Responses.Types;
using MediatR;

namespace Catalog.Application.Features.Requests.Queries.Types;
public class GetAllTypesQueryRequest: IRequest<List<TypeResponse>>
{
}
