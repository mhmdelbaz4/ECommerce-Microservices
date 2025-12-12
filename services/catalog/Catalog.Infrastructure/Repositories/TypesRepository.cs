using AutoMapper;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Infrastructure.Documents;
using Catalog.Infrastructure.Interfaces;
using MongoDB.Driver;
using Entities = Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Repositories;
public class TypesRepository(ICatalogContext _catalogContext,
                            IMapper _mapper) : IGenericRepository<Entities.Type>
{
    public Task Add(Domain.Entities.Type entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.Type>> GetAllDeletedEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Domain.Entities.Type>> GetAllEntitiesAsync()
    {
        var typesDocuments = await _catalogContext.Types.Find(t => !t.IsDeleted).ToListAsync();
        return _mapper.Map<IEnumerable<Domain.Entities.Type>>(typesDocuments);
    }

    public Task<Domain.Entities.Type> GetDeletedEntityByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Type> GetEntityByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Domain.Entities.Type entity)
    {
        throw new NotImplementedException();
    }
}
