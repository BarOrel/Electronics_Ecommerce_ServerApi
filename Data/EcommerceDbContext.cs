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
                new UserApplication { UserName = "bar1236", PasswordHash = "bar554401", AddressId = 1, Email = "bari0777@walla.com", FullName = "Bar Orel" }


                );




            modelBuilder.Entity<Product>().HasData(
                //gaming console
                new Product { Id = 1, Name = "PlayStation 5", Price = 499, Manufacturer = Manufacturer.Sony, ImgUrl = "https://www.citypng.com/public/uploads/preview/-11591925787cggjhepdvq.png", ReleaseDate = DateTime.Now, Category = Category.VideoGame_Console, Description = "The PlayStation 5 (PS5) is a home video game console developed by Sony Interactive Entertainment. It was announced as successor to the PlayStation 4 in April 2019, was launched on November 12, 2020" },
                new Product { Id = 2, Name = "PlayStation 4", Price = 299, Manufacturer = Manufacturer.Sony, ImgUrl = "https://www.seekpng.com/png/full/199-1998029_playstation4-vinyl-decal-stickers-for-ps4-game-console.png", ReleaseDate = DateTime.Now, Category = Category.VideoGame_Console, Description = "The PlayStation 4 (PS4) is a home video game console developed by Sony Interactive Entertainment." },
                new Product { Id = 3, Name = "Xbox Series X", Price = 329, Manufacturer = Manufacturer.Microsoft, ImgUrl = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE4mRni?ver=a707", ReleaseDate = DateTime.Now, Category = Category.VideoGame_Console, Description = "Xbox Series X is launching at participating retailers worldwide on 10 November 2020." },
                new Product { Id = 4, Name = "Xbox ", Price = 329, Manufacturer = Manufacturer.Microsoft, ImgUrl = "https://www.skinit.com/media/wysiwyg/category/skins/gaming-skins/microsoft/xbox-one-s-desktop.png", ReleaseDate = DateTime.Now, Category = Category.VideoGame_Console, Description = "Xbox One S is launching at participating retailers worldwide on 10 Aogust 2019." },

                //smartphones
                new Product { Id = 5, Name = "Iphone 12", Price = 699, Manufacturer = Manufacturer.Apple, ImgUrl = "https://pngimg.com/d/iphone_12_PNG3.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "iPhone 12 includes a faster and more powerful Image Signal Processor that enabled new camera functionality for 2020" },
                new Product { Id = 6, Name = "Iphone 12 Pro", Price = 799, Manufacturer = Manufacturer.Apple, ImgUrl = "https://assets.swappie.com/cdn-cgi/image/width=600,height=600,fit=contain,format=auto/swappie-iphone-12-pro-max-graphite.png?v=13", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "iPhone 12 pro includes a faster and more powerful Image Signal Processor that enabled new camera functionality for 2020" },
                new Product { Id = 7, Name = "Iphone 12 Max", Price = 899, Manufacturer = Manufacturer.Apple, ImgUrl = "https://pngimg.com/uploads/iphone_12/iphone_12_PNG3.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "iPhone 12 max includes a faster and more powerful Image Signal Processor that enabled new camera functionality for 2020." },

                new Product { Id = 8, Name = "Iphone 13", Price = 799, Manufacturer = Manufacturer.Apple, ImgUrl = "https://images.dailyobjects.com/marche/product-images/1101/slick-phone-case-cover-for-iphone-13-images/Nimbus-Phone-Case-Cover-For-iPhone-13.png?tr=cm-pad_resize,v-2", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The iPhone 13 and iPhone 13 Mini (stylized as iPhone 13 mini) are smartphones designed, developed, markete." },
                new Product { Id = 9, Name = "Iphone 13 Pro", Price = 799, Manufacturer = Manufacturer.Apple, ImgUrl = "https://www.pngmart.com/files/21/iPhone-13-Pro-PNG-Image.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The iPhone 13 and iPhone 13 Mini (stylized as iPhone 13 mini) are smartphones designed, developed, marketed." },
                new Product { Id = 10, Name = "Iphone 13 Max", Price = 899, Manufacturer = Manufacturer.Apple, ImgUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-13-pro-max-silver-select?wid=940&hei=1112&fmt=png-alpha&.v=1631652956000", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The iPhone 13 and iPhone 13 Mini (stylized as iPhone 13 mini) are smartphones designed, developed, marketed" },

                new Product { Id = 11, Name = "Iphone 14 ", Price = 799, Manufacturer = Manufacturer.Apple, ImgUrl = "https://png.monster/wp-content/uploads/2022/09/png.monster-209.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "Apple's iPhone 14 models are identical in design to the iPhone 13 models, featuring flat edges, an aerospace-grade aluminum enclosure, and a glass back that enables wireless charging" },
                new Product { Id = 12, Name = "Iphone 14 Pro", Price = 899, Manufacturer = Manufacturer.Apple, ImgUrl = "https://s7d1.scene7.com/is/image/dish/iPhone_14_Pro_Deep_Purple_phonewall?$ProductBase$", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "Apple's iPhone 14 models are identical in design to the iPhone 13 models, featuring flat edges, an aerospace-grade aluminum enclosure, and a glass back that enables wireless charging" },
                new Product { Id = 13, Name = "Iphone 14 Max", Price = 950, Manufacturer = Manufacturer.Apple, ImgUrl = "https://assets.swappie.com/cdn-cgi/image/width=600,height=600,fit=contain,format=auto/swappie-iphone-14-pro-max-gold-back.png?v=13", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "Apple's iPhone 14 models are identical in design to the iPhone 13 models, featuring flat edges, an aerospace-grade aluminum enclosure, and a glass back that enables wireless charging" },

                new Product { Id = 14, Name = "Galaxy S21", Price = 799, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://images.samsung.com/is/image/samsung/p6pim/il/galaxy-s21/gallery/il-galaxy-s21-5g-g991-sm-g991bzadmec-359240688", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Samsung Galaxy S21 is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series." },
                new Product { Id = 15, Name = "Galaxy S21+", Price = 899, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://images.samsung.com/is/image/samsung/p6pim/sg/galaxy-s21/gallery/sg-galaxy-s21-5g-g996-sm-g996bzsgxsp-368336436?$650_519_PNG$", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Samsung Galaxy S21 is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series." },
                new Product { Id = 16, Name = "Galaxy S21 Ultra", Price = 950, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://images.samsung.com/is/image/samsung/p6pim/ca/galaxy-s21/gallery/ca-galaxy-s21-ultra-5g-g988-sm-g998wzkaxac-thumb-368336282", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Samsung Galaxy S21 is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series." },

                new Product { Id = 17, Name = "Galaxy S22", Price = 950, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://cdn.shopify.com/s/files/1/0552/5821/8633/products/96c7b58c6fadffd51dc61cea80e2901d.png?v=1666343215", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Samsung Galaxy S22 is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series." },
                new Product { Id = 18, Name = "Galaxy S22+", Price = 950, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://d3m9l0v76dty0.cloudfront.net/system/photos/9279758/large/bc931c6792b57d70fcffdd20939e018e.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Samsung Galaxy S22+ is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series." },
                new Product { Id = 19, Name = "Galaxy S22 ultra", Price = 950, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://media.bechtle.com/is/180712/1c4b3d4ee288fc9434f5175bf56070570/c3/gallery/1200cd0e901a448ab8c94e14a710c1b4?version=0", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Samsung Galaxy S22 ultra is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series." },

                new Product { Id = 20, Name = "Galaxy S23", Price = 950, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://nextech.co.il/wp-content/uploads/2023/02/green-8.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Samsung Galaxy S22 is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series." },
                new Product { Id = 21, Name = "Galaxy S23+", Price = 950, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://d3m9l0v76dty0.cloudfront.net/system/photos/9279758/large/bc931c6792b57d70fcffdd20939e018e.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Samsung Galaxy S22+ is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series." },
                new Product { Id = 22, Name = "Galaxy S23 ultra", Price = 950, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://www.att.com/idpassets/global/devices/phones/samsung/samsung-galaxy-s23-ultra/carousel/phantomblack/phantomblack-4.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Samsung Galaxy S22 ultra is a series of Android-based smartphones designed, developed, marketed, and manufactured by Samsung Electronics as part of its Galaxy S series. They collectively serve as the successor to the Samsung Galaxy S20 series." },

                new Product { Id = 23, Name = "Xiaomi Note 11 Pro", Price = 950, Manufacturer = Manufacturer.Xiaomi, ImgUrl = "https://www.bug.co.il/images/site/products/e275ec4b-eeab-4345-b35f-05b8233f031f.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Xiaomi 11s is a good all-rounder. It's powerful, the camera produces nice images during the day and night, and the screen is superior to phone mid-rangers, with more pixels and above-average brightness. While the battery life is not standard-setting, it's solid, and the charging speed is excellent." },
                new Product { Id = 24, Name = "Xiaomi Note 11S", Price = 950, Manufacturer = Manufacturer.Xiaomi, ImgUrl = "http://i01.appmifile.com/webfile/globalimg/pic/Redmi-Note-11S-Blanco-Perla!800x800!85.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Xiaomi 11 pro is a good all-rounder. It's powerful, the camera produces nice images during the day and night, and the screen is superior to phone mid-rangers, with more pixels and above-average brightness. While the battery life is not standard-setting, it's solid, and the charging speed is excellent." },
                new Product { Id = 25, Name = "Xiaomi Note 11", Price = 950, Manufacturer = Manufacturer.Xiaomi, ImgUrl = "https://d3m9l0v76dty0.cloudfront.net/system/photos/11206223/large/a56d598ce836e66e4b62f2272802da0b.png", ReleaseDate = DateTime.Now, Category = Category.Mobile_Phone, Description = "The Xiaomi 11 is a good all-rounder. It's powerful, the camera produces nice images during the day and night, and the screen is superior to phone mid-rangers, with more pixels and above-average brightness. While the battery life is not standard-setting, it's solid, and the charging speed is excellent." },

                //smart watches
                new Product { Id = 26, Name = "Apple Watch ultra", Price = 950, Manufacturer = Manufacturer.Apple, ImgUrl = "https://cdn.shopify.com/s/files/1/0157/3520/products/NM00736685_0007_855848007366_A2-PhotoRoom.png?v=1664873211", ReleaseDate = DateTime.Now, Category = Category.Smart_Watches, Description = "The biggest and brightest Apple Watch display. The Always‑On Retina display is 2000 nits at its peak and twice as bright as any other Apple Watch. The bigger display provides more room for workout metrics and detail‑packed watch faces." },
                new Product { Id = 26, Name = "Apple Watch series 8 41mm", Price = 650, Manufacturer = Manufacturer.Apple, ImgUrl = "https://hotstore.hotmobile.co.il/media/catalog/product/cache/a73c0d5d6c75fbb1966fe13af695aeb7/s/t/starlight_1_2.png", ReleaseDate = DateTime.Now, Category = Category.Smart_Watches, Description = "Apple Watch Series 8 has an innovative new sensor that accurately samples your temperature while you sleep. Shifts in temperature provide insights into your overall wellness and can be caused by things like alcohol, exercise, or even illness." },
                new Product { Id = 27, Name = "Apple Watch series 8 45mm", Price = 550, Manufacturer = Manufacturer.Apple, ImgUrl = "https://hotstore.hotmobile.co.il/media/catalog/product/cache/a73c0d5d6c75fbb1966fe13af695aeb7/m/i/midnight02_1.png", ReleaseDate = DateTime.Now, Category = Category.Smart_Watches, Description = "Apple Watch Series 8 has an innovative new sensor that accurately samples your temperature while you sleep. Shifts in temperature provide insights into your overall wellness and can be caused by things like alcohol, exercise, or even illness." },
                new Product { Id = 28, Name = "Apple Watch se", Price = 500, Manufacturer = Manufacturer.Apple, ImgUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/MPLT3ref_VW_PF+watch-44-alum-midnight-nc-se_VW_PF_WF_SI?wid=2000&hei=2000&fmt=png-alpha&.v=1660778411615,1660759426989", ReleaseDate = DateTime.Now, Category = Category.Smart_Watches, Description = "Apple Watch Series 8 has an innovative new sensor that accurately samples your temperature while you sleep. Shifts in temperature provide insights into your overall wellness and can be caused by things like alcohol, exercise, or even illness." },

                new Product { Id = 29, Name = "Samsung watch 5 Pro", Price = 930, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://api.sammobile.com/static/3-027_product_galaxy_watch5pro_blacktitanium_r_perspective_LI.png?1660133183", ReleaseDate = DateTime.Now, Category = Category.Smart_Watches, Description = "Apple Watch Series 8 has an innovative new sensor that accurately samples your temperature while you sleep. Shifts in temperature provide insights into your overall wellness and can be caused by things like alcohol, exercise, or even illness." },
                new Product { Id = 30, Name = "Samsung watch 5", Price = 899, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://images.samsung.com/is/image/samsung/p6pim/ph/2208/gallery/ph-galaxy-watch5-44mm-sm-r910nzaaasa-533197643?$650_519_PNG$", ReleaseDate = DateTime.Now, Category = Category.Smart_Watches, Description = "Apple Watch Series 8 has an innovative new sensor that accurately samples your temperature while you sleep. Shifts in temperature provide insights into your overall wellness and can be caused by things like alcohol, exercise, or even illness." },
                new Product { Id = 31, Name = "Samsung watch 4 classic", Price = 650, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://images.samsung.com/is/image/samsung/p6pim/my/2108/gallery/my-galaxy-watch4-classic-398835-sm-r890nzkaxme-481102149?$650_519_PNG$", ReleaseDate = DateTime.Now, Category = Category.Smart_Watches, Description = "Apple Watch Series 8 has an innovative new sensor that accurately samples your temperature while you sleep. Shifts in temperature provide insights into your overall wellness and can be caused by things like alcohol, exercise, or even illness." },

                //Tablet
                new Product { Id = 32, Name = "Apple ipad pro 12.9", Price = 1199, Manufacturer = Manufacturer.Apple, ImgUrl = "https://www.firstnet.com/content/dam/firstnet/images/tablets-and-laptops/firstnet-apple-ipad-pro-12-9-in-2022.png", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "Description. The iPad Pro 12.9-inch (2022) comes with 12.9-inch display and Apple's M2 processor. Specs also include Dual camera setup on the back with 12MP main sensor and up to 16GB RAM and 2TB internal storage." },
                new Product { Id = 33, Name = "Apple ipad pro 11", Price = 999, Manufacturer = Manufacturer.Apple, ImgUrl = "https://www.theiphonewiki.com/w/images/thumb/1/14/IPadPro_11-inch_2nd_generation.png/300px-IPadPro_11-inch_2nd_generation.png", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "The 11-inch iPad Pro display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 11 inches diagonally (actual viewable area is less)." },
                new Product { Id = 34, Name = "Apple ipad Air 10.9", Price = 1000, Manufacturer = Manufacturer.Apple, ImgUrl = "https://pro-digital.co.il/wp-content/uploads/2021/11/8901a1969a9b3023daf14443ac4d7225.png", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "In theory, the ‌iPad Air‌ is a more compelling package with the ‌M1‌ chip, 4GB of additional memory, a dedicated media engine, ‌Stage Manager‌ for multitasking, a better display, and a much better ‌Apple Pencil‌ experience, but in practice, users are unlikely to notice much difference between the devices.9 2022" },
                new Product { Id = 35, Name = "Apple ipad 10.9", Price = 1169, Manufacturer = Manufacturer.Apple, ImgUrl = "https://d3m9l0v76dty0.cloudfront.net/system/photos/9055438/large/e81a08e554af37be8a6d600824a29e57.png", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "The stunning 10.9-inch Liquid Retina display makes an incredible canvas. So you can doodle, take notes, mark up documents, and a lot more with Apple Pencil. Record and refine from anywhere with high-quality built-in mics and landscape stereo speakers." },
                new Product { Id = 36, Name = "Apple ipad 10.2", Price = 759, Manufacturer = Manufacturer.Apple, ImgUrl = "https://hotstore.hotmobile.co.il/media/catalog/product/cache/a73c0d5d6c75fbb1966fe13af695aeb7/h/6/h69114077_1000x1000_2.png", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "The iPad 10.2 (2021) is offering 10.2 inch display that supports Apple Pencil and it has Wi-Fi only model or with LTE enabled. The tablet comes with 8526mAh battery, Apple A13 Bionic processor and offers two internal storage variants - 64GB or 256GB. Prices start from $329." },

                new Product { Id = 37, Name = "Samsung Galaxy Tab S8 Ultra", Price = 1299, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://images.samsung.com/is/image/samsung/p6pim/sg/sm-x906bzajxsp/gallery/sg-galaxy-tab-s8-ultra-5g-x906-sm-x906bzajxsp-534194325?$650_519_PNG$", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 38, Name = "Samsung Galaxy Tab 8+", Price = 889, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://res-1.cloudinary.com/grover/image/upload/v1646833195/cieclvic1gpo7h7sqgyv.png", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 40, Name = "Samsung Galaxy Tab A8", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://d3m9l0v76dty0.cloudfront.net/system/photos/8705804/original/f4a99cf07a6c9ec750e0e18778d64bb0.png", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 40, Name = "Samsung Galaxy Tab A7 Lite", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "https://hotstore.hotmobile.co.il/media/catalog/product/cache/a73c0d5d6c75fbb1966fe13af695aeb7/e/0/e010022011_3_1_1_1.png", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },

                new Product { Id = 40, Name = "", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 40, Name = "", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 40, Name = "", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 40, Name = "", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 40, Name = "", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 40, Name = "", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 40, Name = "", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" },
                new Product { Id = 40, Name = "", Price = 759, Manufacturer = Manufacturer.Samsung, ImgUrl = "", ReleaseDate = DateTime.Now, Category = Category.Tablet, Description = "" }



                //Television



                //Desktop


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
