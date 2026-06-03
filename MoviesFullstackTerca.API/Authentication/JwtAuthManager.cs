using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesFullstackTerca.API.Authentication;

public static class JwtAuthManager
{
    public static string GenerateToken(string userName)
    {
        // Carrega as configurações do arquivo appsettings.json da pasta onde a aplicação está rodando.
        IConfigurationRoot configuration = new ConfigurationBuilder()
            // Define a pasta base usada para localizar o arquivo de configuração.
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            // Adiciona o appsettings.json como fonte de configurações.
            .AddJsonFile("appsettings.json")
            // Monta o objeto final que permite acessar as configurações carregadas.
            .Build();

        var jwtSection = configuration.GetSection("JwtSettings");
        var jwtSettings = jwtSection.Get<JwtSettings>()
            ?? throw new InvalidOperationException("JwtSettings section is not configured. Please add JwtSettings in appsettings.json.");

        if (string.IsNullOrEmpty(jwtSettings.Key))
            throw new InvalidOperationException("JwtSettings.Key is not configured.");

        var key = Encoding.ASCII.GetBytes(jwtSettings.Key);

        // Claims são informações sobre o usuário que ficam dentro do token JWT.
        // Aqui estamos guardando o nome do usuário para a API saber quem está autenticado.
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName)
        };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256
        );

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(jwtSettings.DurationMinutes),
            Issuer = jwtSettings.Issuer,
            Audience = jwtSettings.Audience,
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

    }
}
