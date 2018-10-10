using System.Linq;
using Arqsis.Model.Category;
using Arqsis.Model.Finish;
using Arqsis.Model.Product;
using Arqsis.Model.Restriction;
using Microsoft.EntityFrameworkCore;

namespace Arqsis.Infrastructure.Context
{
    public sealed class ApiContext : DbContext
    {
        public DbSet<Finish> Finishes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            
            modelBuilder.Entity<Finish>().HasKey(f => f.FinishId);
            
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<Restriction>().HasKey(r => r.RestrictionId);
            
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().OwnsOne(c => c.Dimension)
                .Property(p=>p.MinDepthInMillimeters)
                .HasColumnName("MinDepthInMillimeters");
            modelBuilder.Entity<Product>().OwnsOne(c => c.Dimension)
                .Property(p=>p.MinHeightInMillimeters)
                .HasColumnName("MinHeightInMillimeters");
            modelBuilder.Entity<Product>().OwnsOne(c => c.Dimension)
                .Property(p => p.MinWeightInMillimeters)
                .HasColumnName("MinWeightInMillimeters");
            
            modelBuilder.Entity<Product>().OwnsOne(c => c.Dimension)
                .Property(p=>p.MaxDepthInMillimeters)
                .HasColumnName("MaxDepthInMillimeters");
            modelBuilder.Entity<Product>().OwnsOne(c => c.Dimension)
                .Property(p=>p.MaxHeightInMillimeters)
                .HasColumnName("MaxHeightInMillimeters");
            modelBuilder.Entity<Product>().OwnsOne(c => c.Dimension)
                .Property(p => p.MaxWeightInMillimeters)
                .HasColumnName("MaxWeightInMillimeters");
           
        }
    }
}