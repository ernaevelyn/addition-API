using Microsoft.EntityFrameworkCore;
using Addition_API.Models; 

namespace Addition_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Addition> Toplamalar { get; set; }
    }
}
