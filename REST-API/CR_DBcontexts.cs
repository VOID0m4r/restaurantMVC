using Microsoft.EntityFrameworkCore;

namespace REST_API
{
    public class CR_DBcontext : DbContext
    {
        public CR_DBcontext(DbContextOptions<CR_DBcontext> options) : base(options) { }
        public DbSet<restaurant> RestaurantSet { get; set; }
    }
}
