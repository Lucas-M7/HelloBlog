using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace API.Services.Token;

public class TokenGenerator
{
    public static string GenerateToken(UserModel userModel)
    {
        var key = "Chave_Super_Secreta_com_pelo_menos_32_bytes";
        var keySecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credencials = new SigningCredentials(keySecurity, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new("Email", userModel.Email),
            new("Name", userModel.Name)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credencials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}