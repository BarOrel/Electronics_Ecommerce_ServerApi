using Data.Models;
using Data.Models.DTO;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_Ecommerce_ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IGenericRepository<Cart> genericRepository;

        public CartController(IGenericRepository<Cart> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(CartDTO cartdto)
        {
            var res =  await genericRepository.GetAll();
            var ves = res.Where(n => n.UserId == cartdto.UserId).FirstOrDefault();
            await genericRepository.Update(ves);
            return Ok(ves);
        }
    }
}
