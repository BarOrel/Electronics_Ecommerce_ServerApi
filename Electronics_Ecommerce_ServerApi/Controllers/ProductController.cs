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
                res = res.Where(n => n.Category == Category.Desktop_PC);
            if (Index == 3)
                res = res.Where(n => n.Category == Category.VideoGame_Console);
            if (Index == 4)
                res = res.Where(n => n.Category == Category.Televsion);
            
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

        



 







