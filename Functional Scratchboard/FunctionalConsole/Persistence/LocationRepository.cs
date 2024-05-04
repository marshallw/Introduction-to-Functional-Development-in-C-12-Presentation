using Types;

namespace Persistence;
public class LocationRepository : IReadOnlyRepository<Location>
{
    public IEnumerable<Location> GetAll() => new[] 
    {
        new Location(1, 1, "New York", true),
        new Location(2, 1, "Chicago", true),
        new Location(3, 1, "San Francisco", false),
        new Location(4, 1, "Boston", true),
        new Location(1, 2, "Regina", true),
        new Location(2, 2, "Winnipeg", true),
        new Location(1, 3, "Vancouver", true)
    };

    public Option<Location> TryGet(int companyId, int locationId) => 
        GetAll().Where(x => x.CompanyId == companyId && x.LocationId == locationId)
                .Select(location => location.ToOptional())
                .SingleOrDefault(Option.None<Location>());
}