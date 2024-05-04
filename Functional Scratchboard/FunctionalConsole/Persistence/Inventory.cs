using Types;
using Persistence.Clients;

namespace Persistence;
public class Inventory
{
    private HttpWrapper _httpClient {get; init;} = new HttpWrapper(new HttpClient());

    public Result<CatalogItem, HttpFailure> UpdateCatalogItemPrices(CatalogItemPricesRequest request) => 
        _httpClient.PostJsonAsync<CatalogItemPricesResponse>("pricing url", request, "auth token", new Dictionary<string, string>(), CancellationToken.None)
                   .ValidateCatalogItem();
}