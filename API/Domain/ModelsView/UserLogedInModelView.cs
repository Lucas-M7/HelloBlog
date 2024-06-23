namespace API.Domain.ModelsView;

public class UserLogedInModelView
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Token { get; set; } = default!;
}