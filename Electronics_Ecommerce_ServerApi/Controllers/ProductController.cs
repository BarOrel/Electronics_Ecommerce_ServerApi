using Data;
using Data.Models;
using Data.Models.Enums;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Electronics_Ecommerce_ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly UserManager<UserApplication> userManager;
        private readonly IGenericRepository<BaseProduct> ProductRepository;
        private readonly IGenericRepository<CreditCard> CreditCardRepository;
        private readonly IGenericRepository<Address> AddressRepository;
        private readonly EcommerceDbContext dbContext;

        public ProductController(UserManager<UserApplication> userManager, IGenericRepository<BaseProduct> productRepository, EcommerceDbContext dbContext)
        {
            this.userManager = userManager;
            this.ProductRepository = productRepository;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
            var res = await ProductRepository.GetAll();          
            return Ok(res);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(BaseProduct newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest();
            }
            
           await ProductRepository.Insert(newProduct); 
            return Ok(newProduct);
        }


      

    }
}
