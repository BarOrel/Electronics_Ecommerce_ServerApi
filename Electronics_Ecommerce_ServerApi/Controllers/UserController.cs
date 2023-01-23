using Data.Models;
using Data.Models.UserModels;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ToDoListPractice.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserApplication> userManager;
        private readonly SignInManager<UserApplication> signInManager;
        private readonly IGenericRepository<Address> addressRepository;

        public UserController(UserManager<UserApplication> userManager, SignInManager<UserApplication> signInManager, IGenericRepository<Address> addressRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.addressRepository = addressRepository;
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

            if(model.Region != "string" && model.City != "string" && model.Street != "string" && model.AddressNumber != "string")
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

             var result = await userManager.CreateAsync(user,model.Password); 

            if(result.Succeeded)
                return Ok(result);

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
                //token = tokenService.GenerateToken(userFromDB)

            });

        }


        //add logout method 

    }
}
