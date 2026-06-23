using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesFullstackTerca.API.Request.Users;
using MoviesFullstackTerca.API.Services;

namespace MoviesFullstackTerca.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]

public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(
        [FromBody] UserCreateRequest request
        )
    {
        var userService = new UserService();

        var isCreated = userService.Create(request);
        if (!isCreated)
            return BadRequest("Error to create user!");

        return Ok("User created with success!");
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var userService = new UserService();

        var user = userService.GetById(id);

        if (user is null)
            return NotFound("User not found!");

        return Ok(user);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(
        int id,
        [FromBody] UserUpdateRequest request)
    {
        var userService = new UserService();
        var isUpdated = userService.Update(id, request);

        if (!isUpdated)
            return BadRequest("Error to update user!");

        return Ok("User updated with success!");
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var userService = new UserService();

        var isDeleted = userService.Delete(id);

        if (!isDeleted)
            return BadRequest("Error to delete user!");

        return Ok($"The user with id {id} has been deleted");
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var userService = new UserService();
        var users = userService.GetAll();
        return Ok(users);
    }
}
