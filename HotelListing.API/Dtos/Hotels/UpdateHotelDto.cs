namespace HotelListing.API.Dtos.Hotels;

public class UpdateHotelDto : BaseHotelDto
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public int Country { get; set; }
}