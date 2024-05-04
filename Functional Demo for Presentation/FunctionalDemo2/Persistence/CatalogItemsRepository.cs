using Types;

namespace Persistence;
public class CatalogItemsRepository : IReadOnlyRepository<CatalogItem>
{
    public IEnumerable<CatalogItem> GetAll() => new[] 
    {
        CatalogItem.Create(1, "MRU123", "Samsung Galaxy S2", "ABCD1234"), 
        CatalogItem.Create(1, "MRU123-V2", "Samsung Galaxy S2 8 GB", "ABCD1234"),
        CatalogItem.Create(2, "MTV543", "Nokia 3310", "QWER5435"),
        CatalogItem.Create(3, "RTR345-1", "Iphone 5", "RDFGSDF23456"),
        CatalogItem.Create(4, "MAR-CH", "Google Nexus 5", "M4Y-4")
    };

    public Option<CatalogItem> TryGet(string slug) =>
        GetAll().Where(item => item.Slug == slug)
                .Select(item => item.ToOptional())
                .SingleOrDefault(Option.None<CatalogItem>());
}