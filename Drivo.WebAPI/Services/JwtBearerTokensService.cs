using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Drivo.WebAPI.Services;

public class JwtBearerTokensService
{
    public JwtBearerTokensService(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public string GetToken(string userName, string roleName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(tokenHandler.CreateToken(new SecurityTokenDescriptor() { SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JwtBearerToken:IssuerSigningKey"))), SecurityAlgorithms.HmacSha256Signature), Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName), new Claim(ClaimTypes.Role, roleName) }), Issuer = Configuration.GetValue<string>("JwtBearerToken:ValidIssuer"), Expires = DateTime.UtcNow.AddDays(7) }));
    }
}
