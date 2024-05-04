using Types;

namespace Domain.Catalog;

public static class CatalogExtensions
{
    public static string GetName(this CatalogItem item) => $"This product is a {item.Name}";

    public static Option<string> GetName(this Option<CatalogItem> option) =>
    option.Map(item => $"This is a {item.Name}");

    public static string MessageIfGetFailed(this Option<string> option, string defaultMessage) => option.Reduce(defaultMessage);
}