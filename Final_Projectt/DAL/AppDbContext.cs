using Final_Projectt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Parallax> Parallaxs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<MarkaCategory> MarkaCategorys { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}