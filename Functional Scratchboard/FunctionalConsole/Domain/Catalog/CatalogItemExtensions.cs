using Types;
using Domain;

namespace Domain.Catalog;
public static class CatalogItemExtensions
{
    public static Option<string> GetName(this Option<CatalogItem> option) => 
        option.Map(item => $"This is a {item.Name}");
    public static string MessageIfGetFailed(this Option<string> option, string defaultMessage) => option.Reduce(defaultMessage);

    public static Option<CatalogItemWithPrice> GetLowestPrice(this Option<CatalogItemWithPrices> item) =>
        item.Map(i => new CatalogItemWithPrice(i.Item, i.Prices.Min(x => x)!));
}