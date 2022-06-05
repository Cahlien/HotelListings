using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Controllers;
using HotelListing.API.Dtos.Hotels;
using HotelListing.API.Models;
using HotelListing.API.Repositories;
using Moq.Protected;
using NuGet.Protocol.Core.Types;
using Xunit.Abstractions;

namespace HotelListing.API.Test;

public class HotelControllerTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    public HotelsController controller { get; set; }
    public IHotelsRepository repo { get; set; }

    public HotelControllerTest(ITestOutputHelper testOutputHelper)
    {

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Hotel, HotelDto>().ReverseMap();
            cfg.CreateMap<Hotel, GetHotelDto>().ReverseMap();
            cfg.CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            cfg.CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
        });
        
        var mapper = new Mapper(config);
        var repository = new Mock<IHotelsRepository>();

        repository.Setup(p => p.GetAsync(It.Ref<int>.IsAny)).ReturnsAsync(new Hotel()
        {
            Id = 1,
            Name = "Place 1",
            Address = "Place 1",
            Country = new Country()
            {
                Id = 1,
                Name = "United States",
                ShortName = "USA",
            },
            CountryId = 1,
            Rating = 4.0
        });

        repository.Setup(p => p.Exists(It.Ref<int>.IsAny)).ReturnsAsync(true);
        repo = repository.Object;
        _testOutputHelper = testOutputHelper;
        controller = new HotelsController(repository.Object, mapper);
    }
    
    [Fact]
    public void InstantiateHotelController_ExpectNotNull()
    {
        controller.Should().NotBeNull();
    }

    [Fact]
    public async void GetHotels_ExpectListNotNull()
    {
        var hotel = await repo.GetAsync(1);
    }
    
}