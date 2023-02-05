using Data;
using Data.Models;
using Data.Models.DTO;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Electronics_Ecommerce_ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IGenericRepository<Cart> genericRepository;
        private readonly EcommerceDbContext ecommerceDbContext;

        public CartController(IGenericRepository<Cart> genericRepository, EcommerceDbContext ecommerceDbContext)
        {
            this.genericRepository = genericRepository;
            this.ecommerceDbContext = ecommerceDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            var res = await ecommerceDbContext.Carts.Include(n => n.Products).ToListAsync();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(CartDTO cartdto)
        {
            var res = await ecommerceDbContext.Carts.Include(n => n.Products).ToListAsync();
            var ves = res.Where(n => n.UserId == cartdto.UserId).FirstOrDefault();

            CartProduct cartProduct = new()
            {
                Id = cartdto.Product.Id,
                Name = cartdto.Product.Name,
                Description= cartdto.Product.Description,
                ImgUrl= cartdto.Product.ImgUrl,
                Price= cartdto.Product.Price,
                Discount= cartdto.Product.Discount,
                ReleaseDate= cartdto.Product.ReleaseDate,
                Color= cartdto.Product.Color,
                Manufacturer= cartdto.Product.Manufacturer,
                Category= cartdto.Product.Category,
                Storage= cartdto.Product.Storage,
                Type= cartdto.Product.Type,
                MilliampHours= cartdto.Product.MilliampHours,
                Resolution= cartdto.Product.Resolution,
                Panel= cartdto.Product.Panel,
                Inch= cartdto.Product.Inch,
                OperationSystem= cartdto.Product.OperationSystem,
                SizeMM= cartdto.Product.SizeMM,
                CpuType= cartdto.Product.CpuType,
                CpuName= cartdto.Product.CpuName,
                GpuType= cartdto.Product.GpuType,
                GpuName= cartdto.Product.GpuName,
                Cores= cartdto.Product.Cores,
                Threads= cartdto.Product.Threads,

            };
            
            ves.Products.Add(cartProduct);
            var what = res.Where(n => n.Products.Any(l => l == cartProduct));
            if (what == null) { ecommerceDbContext.CartProducts. }
            ecommerceDbContext.Carts.Update(ves);

            await ecommerceDbContext.SaveChangesAsync();
            return Ok(ves);
        }
    }
}
