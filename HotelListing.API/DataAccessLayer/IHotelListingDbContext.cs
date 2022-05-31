using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.DataAccessLayer;

public interface IHotelListingDbContext
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }
}