
using System.Runtime.CompilerServices;

public abstract record Product(string Slug, string Name, string Description);

public record PublicProduct(string Slug, string Name, string Description, string Vendor) : Product(Slug, Name, Description);

public record PrivateProduct(string Slug, int CompanyId, string Name, string Description) : Product(Slug, Name, Description);


public static class ProductExtensions
{
    public static string GetDetails(this Product product) =>
        product switch 
        {  
            PublicProduct pub => $"{pub.Name} ({pub.Slug}) by {pub.Vendor}",
            PrivateProduct priv => $"{priv.Name} ({priv.Slug}), sold and built by {priv.CompanyId}",
            _ => default!
        };

    public static TResult MapAny<Product, TResult>(this Product product, Func<PublicProduct, TResult> publicFunc, Func<PrivateProduct, TResult> privateFunc) =>
        product switch
        {
            PublicProduct pub => publicFunc(pub),
            PrivateProduct priv => privateFunc(priv),
            _ => default!
        };

}