using Microsoft.EntityFrameworkCore;
using StoneService.Models;

namespace StoneService.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Stone> stones { get; set; }
    }
}
