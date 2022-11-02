using Itstep.Delivery.GlobalDictionary.Api.Entities;
using Itstep.Delivery.GlobalDictionary.Api.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Itstep.Delivery.GlobalDictionary.Api.Controllers;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    private readonly DataContext _dbContext;

    public CitiesController(DataContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    [HttpGet("retrieve-cities-collection")]
    public async Task<IActionResult> GetCitiesCollection()
    {
        var cities = await _dbContext.Cities.ToListAsync();
        return Ok(cities);
    }

    [HttpGet("retrieve-city-by-id/{id}")]
    public async Task<IActionResult> GetCityById(int id)
    {
        var cities = await _dbContext.Cities.FindAsync(id);
        return Ok(cities);
    }
    [HttpPost("post-one-city")]
    public async Task<IActionResult> PostOneCity(ModelCity modelCity)
    {
        City city = new City()
        {
            Name = modelCity.Name,
            CountryId = modelCity.CountryId,
            Country = await _dbContext.Countries.FindAsync(modelCity.CountryId)
        };
        _dbContext.Cities.Add(city);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
