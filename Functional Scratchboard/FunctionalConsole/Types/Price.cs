// See https://aka.ms/new-console-template for more information
namespace Types;
public record Price(int PriceId, string Slug, int LocationId, decimal RegularPrice);


public class PriceClass(int PriceId, string Slug, int CompanyId, decimal RegularPrice)
{
    public int PriceId {get; init;} = PriceId;
    public string Slug {get; init;} = Slug;
    public int CompanyId {get; init;} = CompanyId;
    public decimal RegularPrice {get; init;} = RegularPrice;
}