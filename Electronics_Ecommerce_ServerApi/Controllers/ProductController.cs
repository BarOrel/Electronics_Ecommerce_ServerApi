using Data;
using Data.Models;
using Data.Models.DTO;
using Data.Models.Enums;
using Data.Repository;
using Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Electronics_Ecommerce_ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly UserManager<UserApplication> userManager;
        IGenericRepository<Product> productRepository;
        private readonly IGenericRepository<Cart> cartRepository;
        private readonly IService service;
        private readonly EcommerceDbContext dbContext;


        public ProductController(UserManager<UserApplication> userManager, IService service, IGenericRepository<Product> genericRepository,
             IGenericRepository<Cart> CartRepository,
        EcommerceDbContext dbContext )
        {
            this.userManager = userManager;
            this.service = service;
            this.dbContext = dbContext;
            this.productRepository = genericRepository;
            cartRepository = CartRepository;
        }

        [HttpGet("{Index}")]
        public async Task<IActionResult> GetAll(int Index) 
        { 
            var res = await productRepository.GetAll();
            

            if (Index == 1)
                res = res.Where(n => n.Category == Category.Mobile_Phone);
            if (Index == 2)
                res = res.Where(n => n.Category == Category.Tablet);
            if (Index == 3)
                res = res.Where(n => n.Category == Category.Smart_Watches);

            if (Index == 4)
                res = res.Where(n => n.Category == Category.Televsion);

             if (Index == 5)
                res = res.Where(n => n.Category == Category.Desktop_PC);
            if (Index == 6)
                res = res.Where(n => n.Category == Category.Procesor_PC);
            if (Index == 7)
                res = res.Where(n => n.Category == Category.GraphicsCard_PC);
            if (Index == 8)
                res = res.Where(n => n.Category == Category.Laptop_PC);

             if (Index == 9)
                res = res.Where(n => n.Category == Category.VideoGame_Console);
            if (Index == 10)
                res = res.Where(n => n.Category == Category.Accessories_Console);

            if (Index == 11)
                res = res.Where(n => n.Category == Category.ComputerAccessories_Keyboard);
            if (Index == 12)
                res = res.Where(n => n.Category == Category.ComputerAccessories_Mouse);
             if (Index == 13)
                res = res.Where(n => n.Category == Category.ComputerAccessories_Monitor);
            if (Index == 14)
                res = res.Where(n => n.Category == Category.ComputerAccessories_Speakers);
            if (Index == 15)
                res = res.Where(n => n.Category == Category.ComputerAccessories_Headphones);
           
            
            return Ok(res);
        }


        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (product == null) { return BadRequest(); }
            await productRepository.Insert(product);
            return Ok(product);           
        }
        
        [HttpPost("AddCart")]
        public async Task<IActionResult> AddCart(Cart cart)
        {
           
            var res = await dbContext.Carts.Include(n => n.Products).ToListAsync();
            
            return Ok(res);
        }




        












    }


















}

        



 







