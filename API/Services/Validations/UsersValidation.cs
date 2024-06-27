using System.Text.RegularExpressions;
using API.Data;
using API.Domain.DTOs;
using API.Domain.ModelsView;

namespace API.Services.Validations;

public class UsersValidation
{
    private readonly ApplicationContext _context;

    public UsersValidation(ApplicationContext context)
    {
        _context = context;
    }

    public ValidationErrorModelView ValidationUser(RegisterDTO registerDTO)
    {
        var validation = new ValidationErrorModelView
        {
            Messages = []
        };

        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        if (!Regex.IsMatch(registerDTO.Email, emailPattern))
            validation.Messages.Add("Invalid email address. Do not use invalid characters.");

        if (_context.Users.Any(x => x.Email == registerDTO.Email))
            validation.Messages.Add("This email is already in use.");

        if (string.IsNullOrEmpty(registerDTO.Email))
            validation.Messages.Add("The email must not be empty.");

        if (string.IsNullOrEmpty(registerDTO.Name))
            validation.Messages.Add("The name must not be empty.");

        if (_context.Users.Any(u => u.Name == registerDTO.Name))
            validation.Messages.Add("This name is already in use.");

        if (string.IsNullOrEmpty(registerDTO.Password) || registerDTO.Password.Length < 4)     
            validation.Messages.Add("The password must contain at least 4 characters and must not be empty.");

        return validation;
    }
}