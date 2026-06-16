using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesFullstackTerca.API.Authentication;
using MoviesFullstackTerca.API.DatabaseContext;
using MoviesFullstackTerca.API.Encrypt;
using MoviesFullstackTerca.API.Request.Login;

namespace MoviesFullstackTerca.API.Controllers;

public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] AuthRequest request)
    {
        using var connection = new DataContext();

        var user = connection.Users.AsNoTracking().FirstOrDefault(x => x.Username == request.Username && x.Password == PasswordEncryptor.EncryptPassword(request.Password));

        if (user is null)
            return BadRequest("Login failed!");

        var token = JwtAuthManager.GenerateToken(user.Username);

        return Ok($"Login successfull! Jwt: {token}");
    }
}
