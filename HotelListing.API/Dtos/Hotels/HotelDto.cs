namespace HotelListing.API.Dtos.Hotels;

public class HotelDto : BaseHotelDto
{
    public int Id { get; set; }
    public int CountryId { get; set; }
}