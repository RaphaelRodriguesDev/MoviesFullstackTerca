namespace MoviesFullstackTerca.API.Authentication;

public class JwtSettings
{
    /// Chave secreta utilizada para assinar e validar os tokens JWT
    public string Key { get; set; } = string.Empty;
    /// Emissor do token - identifica quem criou o token
    public string Issuer { get; set; } = string.Empty;
    // Audiência do token - identifica para quem o token é destinado
    public string Audience { get; set; } = string.Empty;
    /// Duração do token em minutos - define por quanto tempo o token será válido
    public double DurationMinutes { get; set; }

}
