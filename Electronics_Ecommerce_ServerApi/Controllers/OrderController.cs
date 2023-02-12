using System.Collections.Generic;
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
    public class OrderController : ControllerBase
    {
        private readonly IGenericRepository<UserApplication> userRepository;
        private readonly IGenericRepository<Cart> genericRepository;
        private readonly IGenericRepository<Address> addressRepository;
        private readonly IGenericRepository<CreditCard> cCRepository;
        private readonly IGenericRepository<Order> orderRepository;
        private readonly EcommerceDbContext ecommerceDbContext;
        private readonly IGenericRepository<CartProduct> productRepository;

        public OrderController(
            IGenericRepository<UserApplication> userRepository,
            IGenericRepository<Cart> genericRepository,
            IGenericRepository<Address> addressRepository,
            IGenericRepository<CreditCard> CCRepository,
            IGenericRepository<Order> orderRepository,
            EcommerceDbContext ecommerceDbContext,
        IGenericRepository<CartProduct> productRepository)
        {
            this.userRepository = userRepository;
            this.genericRepository = genericRepository;
            this.addressRepository = addressRepository;
            cCRepository = CCRepository;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.ecommerceDbContext = ecommerceDbContext;
        }


        [HttpPost("UserId")]
        public async Task<IActionResult> PlaceAnOrder(string UserId)
        {
            var users = await userRepository.GetAll();
            var user = users.Where(n => n.Id == UserId).FirstOrDefault();

            if (/*user.CreditCardId != 0 &&*/ user.AddressId != 0) { 

            var cart = await ecommerceDbContext.Carts.Include(n => n.Products).Where(n => n.UserId == UserId).FirstOrDefaultAsync();
            
            var finalPrice = 0;
            foreach (var item in cart.Products) { finalPrice += item.Price; }

            Order order = new()
            {
                FinalPrice = finalPrice,
                UserId = UserId,
                OrderTime = DateTime.Now,
                Products = cart.Products
            };
            foreach (var item in cart.Products.Where(n => n.IsOrderd == false))
            {
                item.IsOrderd = true;
                await productRepository.Update(item);
            }

            order.Address = await ecommerceDbContext.Addresses.Where(n=>n.Id == user.AddressId).FirstOrDefaultAsync();

            await orderRepository.Insert(order);
         

            return Ok(order);
            }
            return BadRequest("No Credit Cart Or Address");
        }

    }

}