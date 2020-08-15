using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SepetIslemi.Models.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ogrenciConnection = "Server=.;Database=Northwind;UID=sa;PWD=123";
            
            string kisiselConnection = @"Server=LAPTOP-7LCA6UTU\SQLEXPRESS;Database=Northwind;Integrated Security=true";

            optionsBuilder.UseSqlServer(connectionString: kisiselConnection);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
