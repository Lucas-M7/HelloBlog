using API.Domain.DTOs;
using API.Domain.Models;

namespace API.Interfaces.IUsers;

public interface IUsersService
{
    UserModel RegisterUser(RegisterDTO registerDTO);
    UserModel ChangePassword(int id, PasswordDTO passwordDTO);
    UserModel ChangeEmail(int id, PasswordDTO passwordDTO, EmailDTO emailDTO);
    UserModel LoginUser(LoginDTO loginDTO);
    List<UserModel> ListUsers(int? page);
    UserModel FindUserById(int id); 
    void DeleteUser(int id);
}
