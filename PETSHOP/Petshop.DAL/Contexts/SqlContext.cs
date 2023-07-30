using Microsoft.EntityFrameworkCore;
using Petshop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.DAL.Contexts
{
    public class SqlContext :DbContext
    {
        public SqlContext(DbContextOptions<SqlContext>options):base(options)
        {
            
        }
        public DbSet<Slide> Slide2 { get; set; }
        public DbSet<Admin> Admin2 { get; set; }

        public DbSet<Brand> Brand2 { get; set; }    

        public DbSet<Category> Category2 { get; set; }
        public DbSet<Product> Product2 { get; set; }

        public DbSet<ProductPicture> ProductPicture2 { get; set; }
        public DbSet<ProductCategory> ProductCategory2 { get; set; }
		public DbSet<City> City { get; set; }
		public DbSet<District> District { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductID, x.CategoryID });

			modelBuilder.Entity<District>().HasOne(x => x.City).WithMany(x => x.Districts).OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Order>().HasOne(x => x.City).WithMany(x => x.Orders).OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<OrderDetail>().HasOne(x => x.Product).WithMany(x => x.OrderDetails).OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Product>().HasOne(x=>x.Brand).WithMany(x=>x.Products).OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Category>().HasOne(x => x.ParentCategory).WithMany(x => x.SubCategories).HasForeignKey(x => x.ParentID);

            modelBuilder.Entity<Order>().HasIndex(p => p.OrderNumber).IsUnique().HasDatabaseName("OrderNumberUnique");

            
            modelBuilder.Entity<Admin>().HasData(new Admin { ID = 1, Name = "Efe", Surname = "kurt", UserName = "Efe", Password = "202cb962ac59075b964b07152d234b70" });
        }
    }
}
