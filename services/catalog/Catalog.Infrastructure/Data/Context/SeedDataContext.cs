using Catalog.Infrastructure.Documents;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Context;
public static class SeedDataContext<T> where T : BaseDocument
{
    public static async Task SeedData(IMongoCollection<T> collection, string fileName)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentNullException(nameof(fileName));

        bool collectionHasData = await collection.Find(_ => true).AnyAsync();
        if (collectionHasData)
        {
            Console.WriteLine($"Collection {collection.CollectionNamespace.CollectionName} already contains data. Skipping seed.");
            return;
        }

        string filePath = Path.Combine("InitialData", "Data", fileName);
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"The file {filePath} was not found.");

        string jsonData = await File.ReadAllTextAsync(filePath);
        List<T> data = JsonSerializer.Deserialize<List<T>>(jsonData, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<T>();

        if (!data.Any())
        {
            Console.WriteLine($"No data found in {fileName}. Skipping seed.");
            return;
        }

        await collection.InsertManyAsync(data);
        Console.WriteLine($"Successfully seeded {data.Count} documents to {collection.CollectionNamespace.CollectionName}");
    }
}
