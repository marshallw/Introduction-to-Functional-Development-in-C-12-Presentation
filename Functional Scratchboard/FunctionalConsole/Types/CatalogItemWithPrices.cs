using Types;

public record CatalogItemWithPrices(CatalogItem Item, IEnumerable<Price> Prices);