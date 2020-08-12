using Microsoft.EntityFrameworkCore;
using ShopMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMarket.Data
{
    public class MarketShopContext : DbContext
    {
        public MarketShopContext(DbContextOptions<MarketShopContext> options) : base(options)
        {

        }
        public DbSet<Category> cateories { get; set; }
        public DbSet<CategorytoProduct> categorytoProducts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Users> Userses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Keys
            modelBuilder.Entity<CategorytoProduct>()
                //Two PrimaryKey On One Table
                .HasKey(t => new { t.productId, t.CategoryId });
            //Product And Item
            //modelBuilder.Entity<Product>(
            //    p =>
            //    {
            //        //PrimaryKey in Product
            //        p.HasKey(w => w.id);
            //        //Product And Item One to One RelationShip
            //        p.OwnsOne<Item>(w => w.items);
            //        p.HasOne<Item>(w => w.items).WithOne(w => w.product)
            //        .HasForeignKey<Item>(w => w.ItemId);
            //    }
            //    );
            modelBuilder.Entity<Item>(i =>
            {
                //Change Property Type
                i.Property(w => w.Price).HasColumnType("Money");
                //Set key
                i.HasKey(w => w.ItemId);
            });
            //Set Data in Item Table In Seed
            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ItemId = 1,
                    Price = 854.0M,
                    QuantityInStock = 5
                },
            new Item()
            {
                ItemId = 2,
                Price = 3302.0M,
                QuantityInStock = 8
            },
            new Item()
            {
                ItemId = 3,
                Price = 2500,
                QuantityInStock = 3
            });
            //Set Data in Product Table In Seed
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    id = 1,
                    ItemId = 1,
                    Name = "Learning",
                    Description = "آموزش ASP.Net"
                },
                new Product()
                {
                    id = 2,
                    ItemId = 2,
                    Name = "Learning Blazer",
                    Description = "آموزش Blazer"
                });
            //modelBuilder.Entity<CategorytoProduct>().HasData(
            //    new CategorytoProduct()
            //    {
            //        CategoryId = 1,
            //        productId = 1,

            //    },
            //    new CategorytoProduct()
            //    {
            //        CategoryId = 2,
            //        productId = 1,

            //    },
            //    new CategorytoProduct()
            //    {
            //        CategoryId = 3,
            //        productId = 2,

            //    },
            //    new CategorytoProduct()
            //    {
            //        CategoryId = 4,
            //        productId = 2,

            //    }
            //    );
            #endregion
            #region SeedData Category
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    id = 1,
                    Name = "Asp.Net Core",
                    Discription = "Asp.NetCore 3"
                },
                new Category()
                {
                    id = 2,
                    Name = "Asp.Net Mvc",
                    Discription = "Asp.Net Mvc"
                }

            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
