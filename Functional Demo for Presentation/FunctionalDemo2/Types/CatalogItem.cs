namespace Types;
public record CatalogItem(Guid CatalogItemId, int CompanyId, string Slug, string Name, string CatalogSku)
{
    public static CatalogItem Create(int companyId, string slug, string name, string catalogSku) => new(Guid.NewGuid(), companyId, slug, name, catalogSku);
}