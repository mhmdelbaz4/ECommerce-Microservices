using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Infrastructure.Documents;
using Catalog.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;
public class BrandsRepository(ICatalogContext context,
                              IMapper _mapper) : IGenericRepository<Brand>
{
    public Task Add(Brand entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Brand>> GetAllDeletedEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Brand>> GetAllEntitiesAsync()
    {
        List<BrandDocument> brandsDocument = await context.Brands.Find(b => !b.IsDeleted).ToListAsync();
        return _mapper.Map<IEnumerable<Brand>>(brandsDocument);
    }

    public Task<Brand> GetDeletedEntityByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Brand> GetEntityByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Brand entity)
    {
        throw new NotImplementedException();
    }
}
