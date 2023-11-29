using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("signup")]
    public ActionResult SignUp(User newUser)
    {
        var success = _userService.SignUp(newUser);
        if (!success)
        {
            return BadRequest("User already exists.");
        }

        return Ok("User created successfully.");
    }

    [HttpPost("login")]
    public ActionResult<User> Login(string email, string password)
    {
        var user = _userService.Login(email, password);
        if (user == null)
        {
            return Unauthorized("Invalid credentials.");
        }

        return Ok(user);
    }
}

}