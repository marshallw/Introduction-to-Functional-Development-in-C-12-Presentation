using Persistence;
using Types;
using Domain.Catalog;
using Domain;

CatalogItemsRepository _catalogRepository = new CatalogItemsRepository();

var result = _catalogRepository.TryGet("MTV3")
                               .GetName()
                               .MessageIfGetFailed("We couldn't find anything!");


        Console.WriteLine(result);
