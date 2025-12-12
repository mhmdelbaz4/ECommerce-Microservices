using AutoMapper;
using Catalog.Application.Features.Requests.Queries.Types;
using Catalog.Application.Responses.Types;
using Catalog.Domain.Entities;
using Catalog.Application.Interfaces.Repositories;
using MediatR;

namespace Catalog.Application.Features.Handlers.Queries.Types;
public class GetAllTypesQueryHandler(IMapper _mapper,
                                     IGenericRepository<Domain.Entities.Type> _typesRepository)
                                    : IRequestHandler<GetAllTypesQueryRequest, List<TypeResponse>>
{
    public async Task<List<TypeResponse>> Handle(GetAllTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var types =await _typesRepository.GetAllEntitiesAsync();
        return _mapper.Map<List<TypeResponse>>(types);
    }
}
