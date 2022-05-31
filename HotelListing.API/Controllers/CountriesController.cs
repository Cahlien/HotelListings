using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Dtos.Countries;
using HotelListing.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICountriesRepository _repository;

    public CountriesController(IMapper mapper, ICountriesRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
    {
        var countries = await _repository.GetAllAsync();
        var records = _mapper.Map<List<GetCountryDto>>(countries);

        return Ok(records);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CountryDto>> GetCountry(int id)
    {
        var country = await _repository.GetDetails(id);

        if (country == null) return NotFound();

        return Ok(_mapper.Map<CountryDto>(country));
    }

    // PUT: api/Countries/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
    {
        if (id != updateCountryDto.Id) return BadRequest("Invalid Record Id");

        // _context.Entry(updateCountryDto).State = EntityState.Modified;
        var country = await _repository.GetAsync(id);

        if (country == null) return NotFound();

        _mapper.Map(updateCountryDto, country);

        try
        {
            await _repository.UpdateAsync(country);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CountryExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Countries
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
    {
        var country = _mapper.Map<Country>(createCountryDto);

        var newCountry = await _repository.AddAsync(country);

        return CreatedAtAction("GetCountry", new {id = newCountry.Id}, newCountry);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }

    private async Task<bool> CountryExists(int id)
    {
        return await _repository.Exists(id);
    }
}