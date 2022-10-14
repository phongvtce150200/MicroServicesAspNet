using CandyService.Models;
using Microsoft.EntityFrameworkCore;

namespace CandyService.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Candy> candies { get; set; }
    }
}
