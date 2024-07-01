using API.Data;
using API.Domain.DTOs;
using API.Domain.Models;
using API.Interfaces.IUsers;

namespace API.Services.Users;

public class UsersService : IUsersService
{
    private readonly ApplicationContext _context;

    public UsersService(ApplicationContext context)
    {
        _context = context;
    }

    public UserModel RegisterUser(UserModel user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return user;
    }

    public UserModel LoginUser(LoginDTO loginDTO)
    {
        var user = _context.Users.Where(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password).FirstOrDefault();

        return user ?? throw new FileNotFoundException("Account not found, you want to creat a new perfil?");
    }

    public void DeleteUser(int id)
    {
        var user = FindUserById(id);
        _context.Remove(user);
        _context.SaveChanges();
    }

    public List<UserModel> ListUsers(int? page = 1)
    {
        var query = _context.Users.AsQueryable();

        int itensForPage = 10;

        if (page != null && page > 0)
            query = query.Skip(((int)page - 1) * itensForPage).Take(itensForPage);

        return [.. query];    
    }

    public UserModel FindUserById(int id)
    {
        return _context.Users.FirstOrDefault(i => i.UserId == id)
            ?? throw new FileNotFoundException("User not here.");
    }
}