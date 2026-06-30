namespace MoviesFullstackTerca.API.Services;

public static class RecaptchaService
{
    private static readonly HttpClient _httpClient = new();

    public static async Task<(bool isValid, string reason)> ValidateToken(string token, string expectedAction)
    {
        // Adicionar o resto do código para validar o token do reCAPTCHA aqui
        // ===========================================
        // CODIGO AQUI
        // ===========================================

        return (true, "OK");
    }
}
