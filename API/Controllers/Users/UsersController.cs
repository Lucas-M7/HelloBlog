using API.Data;
using API.Domain.DTOs;
using API.Domain.Models;
using API.Domain.ModelsView;
using API.Interfaces.IUsers;
using API.Services.Token;
using API.Services.Validations;
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
    public IActionResult RegisterOnUser([FromForm] RegisterDTO registerDTO)
    {
        var validUser = new UsersRegisterValidation(_context);
        var validation = validUser.ValidationUser(registerDTO);

        if (validation.Messages.Count > 0)
            return BadRequest(validation);

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

    [AllowAnonymous]
    [HttpPost("users/login")]
    public IActionResult UserLogin([FromForm] LoginDTO loginDTO)
    {
        var validLogin = new UsersLoginValidation(_context);
        var validation = validLogin.ValidationLogin(loginDTO);

        if (validation.Messages.Count > 0)
            return BadRequest(validation);

        var user = _usersService.LoginUser(loginDTO);

        if (user != null)
        {
            string token = TokenGenerator.GenerateToken(user);

            return Ok(new UserLogedInModelView
            {
                Email = user.Email,
                Name = user.Name,
                Token = token
            });
        }
        else
            return Unauthorized("Error logging in, please check your email and password. Or create a new account");
    }
}