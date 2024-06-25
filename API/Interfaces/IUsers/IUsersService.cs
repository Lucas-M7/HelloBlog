using API.Domain.DTOs;
using API.Domain.Models;

namespace API.Interfaces.IUsers;

public interface IUsersService
{
    UserModel RegisterUser(UserModel user);
    UserModel LoginUser(LoginDTO loginDTO);
    List<UserModel> ListUsers(int? page);
    protected UserModel FindUserById(int id); 
    void DeleteUser(int id);
}