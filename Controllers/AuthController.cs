using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Data;
using MyApi.Services;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace MessengerBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;

    public AuthController(AppDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(User user)
    {
        if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            return BadRequest("Username already taken.");

        using var sha256 = SHA256.Create();
        user.PasswordHash = Convert.ToBase64String(sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(user.PasswordHash)));

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login(User user)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

        if (existingUser == null)
            return Unauthorized("Invalid username or password.");

        using var sha256 = SHA256.Create();
        var inputPasswordHash = Convert.ToBase64String(sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(user.PasswordHash)));

        if (existingUser.PasswordHash != inputPasswordHash)
            return Unauthorized("Invalid username or password.");

        var token = _tokenService.CreateToken(existingUser);
        return Ok(new { token });
    }
}
