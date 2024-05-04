using Types;

namespace Persistence;
public class PricingRepository : IReadOnlyRepository<Price>
{
    public IEnumerable<Price> GetAll() => new[] 
    {
        new Price(1,"MRU123", 1 ,1),
        new Price(2, "MTV543", 1, 5),
        new Price(3, "RTR345-1", 1, 10),
        new Price(4, "MAR-CH", 1, 6), 
        new Price(5, "MRU123", 2, 2),
        new Price(6, "MRU123", 3, 3),
        new Price(7, "MTV543", 2, 6),
        new Price(8, "MAR-CH", 3, 5),
        new Price(9, "MTV543", 4, 5),
        new Price(10, "MRU123", 4, 2)
    };

    public IEnumerable<Price> GetPricesBySlug(string slug) =>
        GetAll().Where(price => price.Slug == slug);

    public Option<Price> GetPriceAtLocation(string slug, int locationId) =>
        GetAll().Where(price => price.Slug == slug && price.LocationId == locationId)
                .Select(price => price.ToOptional()).SingleOrDefault(Option.None<Price>());
}