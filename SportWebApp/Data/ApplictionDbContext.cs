using Microsoft.EntityFrameworkCore;

using SportWebApp.Models;

namespace SportWebApp.Data
{
    public class ApplictionDbContext : DbContext
    {
        public ApplictionDbContext(DbContextOptions<ApplictionDbContext> options) : base(options)     
        {
            

        }

        public DbSet<Race> Races { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Address> Addresses { get; set; }
            

    }
}
