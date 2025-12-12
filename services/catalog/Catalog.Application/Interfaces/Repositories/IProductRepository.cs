using Catalog.Application.Dtos;
using Catalog.Application.Responses;
using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces.Repositories;
public interface IProductRepository: IGenericRepository<Product>
{
    Task<PaginationReponse<Product>> GetAllEntitiesAsync(PaginationSpecParams specs);
    Task<List<Product>?> GetAllProductsByNameAsyc(string name);
    Task<List<Product>> GetAllProductsByBrandNameAsync(string brandName);
}
