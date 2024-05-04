using System.Diagnostics;
using Domain;
using Domain.Catalog;
using Types;
using Persistence;

CatalogItemsRepository catalogRepository = new CatalogItemsRepository();
PricingRepository pricingRepository = new PricingRepository();


var catalogItem = catalogRepository.TryGet("MTV543")
                                   .GetName()
                                   .MessageIfGetFailed("Nothing was found");

var item = catalogRepository.TryGet("MTV543")
                            .Map(item => new CatalogItemWithPrices(item, pricingRepository.GetPricesBySlug(item.Slug)))
                            .FindLowestPrice()
                            .GetLocation();
