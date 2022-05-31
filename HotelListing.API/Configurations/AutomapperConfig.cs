using AutoMapper;
using HotelListing.API.Dtos.Countries;
using HotelListing.API.Dtos.Hotels;
using HotelListing.API.Models;

namespace HotelListing.API.Configurations;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Country, GetCountryDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, UpdateCountryDto>().ReverseMap();

        CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        CreateMap<Hotel, GetHotelDto>().ReverseMap();
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
    }
}