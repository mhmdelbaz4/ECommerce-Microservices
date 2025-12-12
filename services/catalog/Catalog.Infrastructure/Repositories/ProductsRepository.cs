using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Infrastructure.Documents;
using Catalog.Infrastructure.Interfaces;
using MongoDB.Driver;
using Catalog.Application.Dtos;
using Catalog.Application.Responses;
namespace Catalog.Infrastructure.Repositories;

public class ProductsRepository(IMapper mapper,
                               ICatalogContext context) :IProductRepository
{
    public async Task Add(Product entity)
    {
        ProductDocument productDocument = mapper.Map<ProductDocument>(entity);
        await context.Products.InsertOneAsync(productDocument);

    }

    public async Task<bool> Delete(string id)
    {
        var filter = Builders<ProductDocument>.Filter.Eq(p => p.Id, id);
        var deleteResult = await context.Products.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<bool> Update(Product entity)
    {
        ProductDocument productDocument = mapper.Map<ProductDocument>(entity);
        var updatedResult =await context.Products.ReplaceOneAsync(filter: g => g.Id == entity.Id.ToString(),
                                                                  replacement: productDocument);
        return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
    }

    public async Task<IEnumerable<Product>> GetAllDeletedEntitiesAsync()
    {
        var filter = Builders<ProductDocument>.Filter.Eq(p => p.IsDeleted, true);
        return await context.Products.Find(filter)
                            .ToListAsync()
                            .ContinueWith(task => mapper.Map<IEnumerable<Product>>(task.Result));
    }

    public async Task<PaginationReponse<Product>> GetAllEntitiesAsync(PaginationSpecParams specs)
    {
        var builder = Builders<ProductDocument>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrWhiteSpace(specs.Search))
            filter &= builder.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(specs.Search, "i"));

        if (!string.IsNullOrWhiteSpace(specs.BrandId))
            filter &= builder.Where(p=> p.Name.ToLower().Contains(specs.Search.ToLower()));

        if (!string.IsNullOrWhiteSpace(specs.TypeId))
            filter &= builder.Eq(p => p.Type.Id, specs.TypeId);

        filter &= builder.Eq(p => p.IsDeleted, false);
        
        var query = context.Products.Find(filter);

        if (!string.IsNullOrWhiteSpace(specs.Sort))
        {
            var sortExpression = Builders<ProductDocument>.Sort.Ascending(p => p.Name);
            if(specs.SortOrder == SortOrder.Ascending)
            {
                sortExpression = specs.Sort.ToLower() switch
                {
                    "price" => Builders<ProductDocument>.Sort.Ascending(p => p.Price),
                    _ => Builders<ProductDocument>.Sort.Ascending(p => p.Name)
                };
            }

            if (specs.SortOrder == SortOrder.Descending)
            {
                sortExpression = specs.Sort.ToLower() switch
                {
                    "price" => Builders<ProductDocument>.Sort.Descending(p => p.Price),
                    _ => Builders<ProductDocument>.Sort.Descending(p => p.Name)
                };
            }
            query = query.Sort(sortExpression);
        }
        long totalCount = await query.CountDocumentsAsync();
        var products = await query.Skip((specs.PageIndex -1 ) * specs.PageSize)
                                .Limit(specs.PageSize)
                                .ToListAsync();
        var productsDocumentPagination = new PaginationReponse<ProductDocument>(specs.PageIndex,
                                                                                specs.PageSize,
                                                                                totalCount,
                                                                                products);

        return mapper.Map<PaginationReponse<Product>>(productsDocumentPagination);
    }

    public async Task<Product> GetDeletedEntityByIdAsync(string id)
    {
        var filter = Builders<ProductDocument>.Filter.And(
                                                            Builders<ProductDocument>.Filter.Eq(p => p.Id, id.ToString()),
                                                            Builders<ProductDocument>.Filter.Eq(p => p.IsDeleted, true)
                                                        );
        var productDocument = await context.Products.Find(filter).FirstOrDefaultAsync();
        return mapper.Map<Product>(productDocument);
    }

    public async Task<Product> GetEntityByIdAsync(string id)
    {
        var filter = Builders<ProductDocument>.Filter.And(
                                                            Builders<ProductDocument>.Filter.Eq(p => p.Id, id.ToString()),
                                                            Builders<ProductDocument>.Filter.Eq(p => p.IsDeleted, false)
                                                        );
        var productDocument = await context.Products.Find(filter).FirstOrDefaultAsync();
        return mapper.Map<Product>(productDocument);
    }

    public async Task<List<Product>?> GetAllProductsByNameAsyc(string name)
    {
        var filter = Builders<ProductDocument>.Filter.And(
                                                            Builders<ProductDocument>.Filter.Eq(p => p.Name, name),
                                                            Builders<ProductDocument>.Filter.Eq(p => p.IsDeleted, false)
                                                        );
        var productsAsDocument =await context.Products.FindAsync(filter);
        return mapper.Map<List<Product>>(productsAsDocument);
    }

    public async Task<List<Product>> GetAllProductsByBrandNameAsync(string brandName)
    {
        var filter = Builders<ProductDocument>.Filter.And(
                                                    Builders<ProductDocument>.Filter.Eq(p => p.Brand.Name, brandName),
                                                    Builders<ProductDocument>.Filter.Eq(p => p.IsDeleted, false)
                                                );
        var productsAsDocument = await context.Products.FindAsync(filter);
        return mapper.Map<List<Product>>(productsAsDocument);
    }

    public Task<IEnumerable<Product>> GetAllEntitiesAsync()
    {
        throw new NotImplementedException();
    }
}