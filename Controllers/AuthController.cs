using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == "admin" && password == "123")
        {
            var token = _jwtService.GenerateToken(username, "Admin");

            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}