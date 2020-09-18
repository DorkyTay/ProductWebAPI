using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Models
{
    public class AppDbContext : DbContext
    {
        // AppDbContext is a representation of your db
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        // DbSet is a representation of the table in your db
        public DbSet<Product> products { get; set; }

    }
}