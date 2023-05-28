using Microsoft.EntityFrameworkCore;
using SalesWebMVC2.Models;

namespace SalesWebMVC2.Data
{
    public class SalesWebMVC2Context : DbContext
    {
        public SalesWebMVC2Context (DbContextOptions<SalesWebMVC2Context> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> SellerMy { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }

    }
}
