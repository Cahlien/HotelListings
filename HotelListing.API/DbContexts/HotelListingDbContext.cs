using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.DbContexts;

public class HotelListingDbContext : DbContext
{
    public HotelListingDbContext(DbContextOptions options) : base(options)
    {
        
    }
}