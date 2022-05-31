using HotelListing.API.Contracts;
using HotelListing.API.DataAccessLayer;
using HotelListing.API.Models;

namespace HotelListing.API.Repositories;

public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
{
    public HotelsRepository(HotelListingDbContext context) : base(context)
    {
        
    }
}