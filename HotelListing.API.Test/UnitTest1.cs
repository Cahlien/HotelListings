using AutoMapper;
using FluentAssertions;
using HotelListing.API.Controllers;
using HotelListing.API.DataAccessLayer;
using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;

namespace HotelListing.API.Test;

public class UnitTest1
{
    public CountriesController controller { get; set; }
    public UnitTest1()
    {
    }
    
    [Fact]
    public void Test1()
    {
        var x = true;
        x.Should().Be(true);
    }
}