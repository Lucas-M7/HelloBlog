using API.Data;
using API.Domain.DTOs;
using API.Domain.Models;
using API.Domain.ModelsView;
using API.Interfaces.IUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Users;

[ApiController]
[Route("api/")]
public class UsersController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IUsersService _usersService;

    public UsersController(ApplicationContext context, IUsersService usersService)
    {
        _context = context;
        _usersService = usersService;
    }

    [AllowAnonymous]
    [HttpPost("users")]
    public IActionResult RegisterOnUser([FromBody] RegisterDTO registerDTO)
    {
        var user = new UserModel
        {
            Email = registerDTO.Email,
            Name = registerDTO.Name,
            Bio = registerDTO.Biography,
            Password = registerDTO.Password
        };

        _usersService.RegisterUser(user);

        return Created($"/user/{user.UserId}", new UserModelView
        {
            Id = user.UserId,
            Email = user.Email,
            Name = user.Name,
            Biography = user.Bio
        });
    }
}