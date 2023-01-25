using Data;
using Data.Models;
using Data.Models.DTO;
using Data.Models.Enums;
using Data.Repository;
using Data.Services;
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
        IGenericRepository<Product> genericRepository;
        private readonly IService service;
        private readonly EcommerceDbContext dbContext;


        public ProductController(UserManager<UserApplication> userManager, IService service, IGenericRepository<Product> genericRepository,
        EcommerceDbContext dbContext )
        {
            this.userManager = userManager;
            this.service = service;
            this.dbContext = dbContext;
            this.genericRepository = genericRepository;
       
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
            var res = await genericRepository.GetAll();
            var ves = res.Where(n => n.Category == Category.Mobile_Phone);
            return Ok(ves);
        }


        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (product == null) { return BadRequest(); }
            await genericRepository.Insert(product);
            return Ok(product);           
        }


    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }


















}

        



 







