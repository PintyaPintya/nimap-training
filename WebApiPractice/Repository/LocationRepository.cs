using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Repository;

public class LocationRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);

    public LocationRepository(ApplicationDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache; 
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
        var cacheKey = "countries";

        // Checks if the countries data is already cached.
        if(!_cache.TryGetValue(cacheKey, out List<Country>? countries))
        {
            // AsNoTracking(): Improves performance for read-only queries by disabling change tracking.
            countries = await _context.Countries.AsNoTracking().ToListAsync();
            _cache.Set(cacheKey, countries, _cacheExpiration);
        }

        return countries ?? new List<Country>();
    }

    public void RemoveCountriesFromCache()
    {
        var cacheKey = "Countries";
        _cache.Remove(cacheKey);
    }

    public async Task AddCountry(Country country)
    {
        await _context.Countries.AddAsync(country);
        await _context.SaveChangesAsync();

        RemoveCountriesFromCache();
    }

    public async Task UpdateCountry(Country country)
    {
        _context.Countries.Update(country);
        await _context.SaveChangesAsync();

        RemoveCountriesFromCache();
    }

    public async Task<List<State>> GetStatesAsync(int countryId)
    {
        string cacheKey = $"States_{countryId}";

        if(!_cache.TryGetValue(cacheKey, out List<State>? states))
        {
            states = await _context.States.Where(s => s.CountryId == countryId).AsNoTracking().ToListAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));

            _cache.Set(cacheKey, states, _cacheExpiration);    
        }

        return states ?? new List<State>();
    }

    public async Task<List<City>> GetCitiesAsync(int stateId)
    {
        string cacheKey = $"Cities_{stateId}";

        if(!_cache.TryGetValue(cacheKey, out List<City>? cities))
        {
            cities = await _context.Cities.Where(c => c.StateId == stateId).AsNoTracking().ToListAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

            _cache.Set(cacheKey, cities, _cacheExpiration);
        }

        return cities ?? new List<City>();
    }
}
