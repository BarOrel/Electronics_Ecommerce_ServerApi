using Data.Models;
using Data.Models.UserModels;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoListPractice.Data.Services.JWT;

namespace ToDoListPractice.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserApplication> userManager;
        private readonly IJWTTokenService tokenService;
        private readonly SignInManager<UserApplication> signInManager;
        private readonly IGenericRepository<Address> addressRepository;
        private readonly IGenericRepository<Cart> cartRepository;

        public UserController(UserManager<UserApplication> userManager, IJWTTokenService tokenService, SignInManager<UserApplication> signInManager, IGenericRepository<Address> addressRepository, IGenericRepository<Cart> cartRepository)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
            this.addressRepository = addressRepository;
            this.cartRepository = cartRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            UserApplication user = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = $"{model.FirstName} {model.LastName}"
            };

            if (model.Region != "string" && model.City != "string" && model.Street != "string" && model.AddressNumber != "string")
            {
                Address address = new()
                {
                    Street = model.Street,
                    City = model.City,
                    Region = model.Region,
                    Number = model.AddressNumber
                };
                await addressRepository.Insert(address);
                var address1 = await addressRepository.Find(address);
                user.AddressId = address1.Id;
            }

            var result = await userManager.CreateAsync(user, model.Password);

            

            if (result.Succeeded)
            {
                Cart cart = new() { UserId = user.Id, };
                await cartRepository.Insert(cart);
                return Ok(result);
            }


            return BadRequest(result);

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var userFromDB = await userManager.FindByNameAsync(model.Username);

            if (userFromDB == null)
                return BadRequest();

            var result = await signInManager.CheckPasswordSignInAsync(userFromDB, model.Password, false);

            if (!result.Succeeded)
                return BadRequest();

            return Ok(new
            {
                result = result,
                username = userFromDB.UserName,
                email = userFromDB.Email,
                userid = userFromDB.Id,
                token = tokenService.GenerateToken(userFromDB)

            });

        }

        //[HttpPost("ValidateToken")]
        //public async Task<IActionResult> ValidateToken(string Token)
        //{
        //    var res = tokenService.ValidateToken(Token);
        //    if (res) { return Ok(Token); }
        //    else { return BadRequest(); }

        //}
    }
}
