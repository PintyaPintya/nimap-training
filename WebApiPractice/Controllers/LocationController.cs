using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Models;
using WebApiPractice.Repository;

namespace WebApiPractice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly LocationRepository _locationRepository;

    public LocationController(LocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    [HttpGet("countries")]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _locationRepository.GetCountriesAsync();
        return Ok(countries);
    }

    private bool CountryExists(int id)
    {
        return _locationRepository.GetCountriesAsync().Result.Any(e => e.CountryId == id);
    }

    [HttpPost("countries")]
    public async Task<IActionResult> AddCountry(Country country)
    {
        try
        {
            if (CountryExists(country.CountryId)) return BadRequest("Country already exists");

            await _locationRepository.AddCountry(country);
            return Ok(country);
        }
        catch (Exception ex)
        {
            var customResponse = new
            {
                Code = 500,
                Message = "Internal Server Error",
                ErrorMessage = ex.Message
            };

            return StatusCode(StatusCodes.Status500InternalServerError, customResponse);
        }
    }

    [HttpPut("countries/{id:int}")]
    public async Task<IActionResult> UpdateCountry(Country country, int id)
    {
        if (id != country.CountryId) return BadRequest();

        if (!CountryExists(id)) return BadRequest("Country Does Not Exist");

        try
        {
            await _locationRepository.UpdateCountry(country);
            return Ok(country);
        }
        catch (Exception ex)
        {
            var customResponse = new
            {
                Code = 500,
                Message = "Internal Server Error",
                ErrorMessage = ex.Message
            };
            return StatusCode(StatusCodes.Status500InternalServerError, customResponse);
        }
    }

    [HttpGet("states/{countryId:int}")]
    public async Task<IActionResult> GetStates(int countryId)
    {
        var states = await _locationRepository.GetStatesAsync(countryId);
        return Ok(states);
    }

    [HttpGet("cities/{stateId:int}")]
    public async Task<IActionResult> GetCities(int stateId)
    {
        var cities = await _locationRepository.GetCitiesAsync(stateId);
        return Ok(cities);
    }
}