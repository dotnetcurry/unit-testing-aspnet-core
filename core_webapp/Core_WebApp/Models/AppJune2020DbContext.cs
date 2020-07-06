using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Models
{
    /// <summary>
    /// Class for DataAccess Layer
    /// </summary>
    public class AppJune2020DbContext : DbContext
    {
        // define the DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // add the constructor that will read the connection string
        /// <summary>
        /// DbContextOptions: Class that will read the 
        /// connection string from the Hosting Environment (?)
        /// </summary>
        /// <param name="options"></param>
        public AppJune2020DbContext
            (DbContextOptions<AppJune2020DbContext> options) : base(options)
        {
        }



        /// <summary>
        /// Method to define RelationShip
        /// across classes so that tables
        /// will be generated based on this relationship
        /// using ModelBuilder class
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category) // product has one category
                .WithMany(p => p.Products) // one category has many products
                .HasForeignKey(p => p.CategoryRowId); // product has foreign key
        }
    }
}
