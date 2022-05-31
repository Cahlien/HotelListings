using HotelListing.API.Dtos.Hotels;

namespace HotelListing.API.Dtos.Countries;

public class CountryDto : BaseCountryDto
{
    public int Id { get; set; }
    public List<HotelDto> Hotels { get; set; }
}