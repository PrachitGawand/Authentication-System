using Microsoft.AspNetCore.Mvc;
using TeamAuthMvc.Dtos;

namespace TeamAuthMvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto model)
        {
            if (model.Email == "admin" && model.Password == "123")
            {
                var token = _jwtService.GenerateToken(model.Email, "Admin");

                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDto model)
        {
            return Ok("User Registered");
        }
    }
}