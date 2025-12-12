using Catalog.Application.Dtos;
using Catalog.Application.Responses;
using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces.Repositories;
public interface IGenericRepository<T> where T:BaseEntity
{
    Task<T> GetEntityByIdAsync(string id);
    Task<T> GetDeletedEntityByIdAsync(string id);
    Task<IEnumerable<T>> GetAllEntitiesAsync();
    Task<IEnumerable<T>> GetAllDeletedEntitiesAsync();
    Task Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(string id);
}
