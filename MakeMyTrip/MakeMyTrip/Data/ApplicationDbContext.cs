using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MakeMyTripTravelPlan.Models;

namespace MakeMyTrip.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MakeMyTripTravelPlan.Models.AirlineService> AirlineService { get; set; } = default!;
        public DbSet<MakeMyTripTravelPlan.Models.Flight> Flight { get; set; } = default!;
    }
}