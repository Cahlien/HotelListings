using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.DataAccessLayer;

public class HotelListingDbContext : DbContext
{
    public HotelListingDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .Entity<Country>()
            .HasData(
                new Country
                {
                    Id = 1,
                    Name = "United States of America",
                    ShortName = "USA"
                },
                new Country()
                {
                    Id = 2,
                    Name = "Russian Federation",
                    ShortName = "RUS"
                },
                new Country()
                {
                    Id = 3,
                    Name = "Hellenic Republic",
                    ShortName = "GRC"
                },
                new Country()
                {
                    Id = 4,
                    Name = "Republic of Ireland",
                    ShortName = "IR"
                },
                new Country()
                {
                    Id = 5,
                    Name = "United Kingdom",
                    ShortName = "UK"
                }
            );

        modelBuilder
            .Entity<Hotel>()
            .HasData(
                new Hotel()
                {
                    Id = 1,
                    Name = "Days Inn",
                    Address = "Panama City, FL",
                    CountryId = 1,
                    Rating = 3.6
                },
                new Hotel()
                {
                    Id = 2,
                    Name = "Matthew and Lisa's Place",
                    Address = "Creachmhaoil, Ireland",
                    CountryId = 4,
                    Rating = 5.0
                }
            );
    }
}