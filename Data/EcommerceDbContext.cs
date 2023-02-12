using Data.Models;
using Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EcommerceDbContext : IdentityDbContext<UserApplication>
    {
         public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
         {
         }

        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserApplication>().HasData(
                new UserApplication { UserName = "bar1236", PasswordHash = "bar554401" , AddressId = 1 , Email = "bari0777@walla.com" ,FullName = "Bar Orel"}


                );




            modelBuilder.Entity<Product>().HasData(
                new Product {Id = 1 , Name = "PlayStation 5" , Price = 499 ,Manufacturer = Manufacturer.Sony , ImgUrl = "https://www.citypng.com/public/uploads/preview/-11591925787cggjhepdvq.png" , ReleaseDate = DateTime.Now ,  Category = Category.None , Description= "The PlayStation 5 (PS5) is a home video game console developed by Sony Interactive Entertainment. It was announced as successor to the PlayStation 4 in April 2019, was launched on November 12, 2020" }


                );


















            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityRole>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Entity<UserApplication>()

                .Ignore(c => c.AccessFailedCount)
                .Ignore(c => c.LockoutEnabled)
                .Ignore(c => c.TwoFactorEnabled)
                .Ignore(c => c.ConcurrencyStamp)
                .Ignore(c => c.LockoutEnd)
                .Ignore(c => c.EmailConfirmed)
                .Ignore(c => c.TwoFactorEnabled)
                .Ignore(c => c.LockoutEnd)
                .Ignore(c => c.AccessFailedCount)
                .Ignore(c => c.PhoneNumberConfirmed);
                


            modelBuilder.Entity<UserApplication>().ToTable("Users");//to change the name of table.

        }

    }
}
