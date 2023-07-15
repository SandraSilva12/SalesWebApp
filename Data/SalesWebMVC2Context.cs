using Microsoft.EntityFrameworkCore;
using SalesWebMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC2.Data
{
    public class SalesWebMVC2Context : DbContext
    {
        public SalesWebMVC2Context(DbContextOptions<SalesWebMVC2Context> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesWebMVC2Context).Assembly);
        }
    }
}


