
namespace API.Domain.DTOs;

public class RegisterDTO
{
    public string Email { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Biography { get; set; } = default!;
    public string Password { get; set; } = default!;
}