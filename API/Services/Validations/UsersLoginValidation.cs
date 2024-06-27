using API.Data;
using API.Domain.DTOs;
using API.Domain.ModelsView;

namespace API.Services.Validations;

public class UsersLoginValidation
{
    private readonly ApplicationContext _context;

    public UsersLoginValidation(ApplicationContext context)
    {
        _context = context;
    }

    public ValidationErrorModelView ValidationLogin(LoginDTO loginDTO)
    {
        var validation = new ValidationErrorModelView
        {
            Messages = []
        };

        if (_context.Users.Any(u => u.Email != loginDTO.Email))
            validation.Messages.Add("Incorrect email, try again or recover password");

        if (_context.Users.Any(u => u.Password != loginDTO.Password))
            validation.Messages.Add("Incorret password, try again or recover password.");

        return validation;
    }
}