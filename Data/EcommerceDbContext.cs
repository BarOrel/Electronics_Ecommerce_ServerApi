using Data.Models;
using Data.Models.Products;
using Data.Models.Products.Computers;
using Data.Models.Products.Computers.Accessories;
using Data.Models.Products.Consoles;
using Data.Models.Products.Mobiles;
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
       
        
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }

        //computers
        public virtual DbSet<DesktopPC> DesktopPCs { get; set; }
        public virtual DbSet<LaptopPC> LaptopPCs { get; set; }
        public virtual DbSet<GamingConsole> GamingConsole { get; set; }

        //Accessories
        public virtual DbSet<HeadPhone> HeadPhones { get; set; }
        public virtual DbSet<aMonitor> Monitors { get; set; }
        public virtual DbSet<Keyboard> Keyboards { get; set; }
        public virtual DbSet<Mouse> Mouses { get; set; }
        public virtual DbSet<Speaker> Speakers { get; set; }
        public virtual DbSet<ConsoleAccessories> ConsoleAccessories { get; set; }

        //mobiles
        public virtual DbSet<MobilePhone> MobilePhones { get; set; }
        public virtual DbSet<SmartWatches> SmartWatches { get; set; }
        public virtual DbSet<Tablet> Tablets { get; set; }

        //parts
        public virtual DbSet<GraphicCard> GraphicCards { get; set; }
        public virtual DbSet<Procesor> Procesors { get; set; }
        
        public virtual DbSet<Television> Televisions { get; set; }









        protected override void OnModelCreating(ModelBuilder builder)
         {
             base.OnModelCreating(builder);
         }
        
    }
}
