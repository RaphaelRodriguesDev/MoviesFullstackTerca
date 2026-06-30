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

public class RecaptchaResponse
{
    public bool success { get; set; } // Indica se a verificação do reCAPTCHA foi bem-sucedida
    public double score { get; set; } // Pontuação atribuída pelo reCAPTCHA, indicando a probabilidade de a interação ser humana
    public string action { get; set; } = string.Empty; // Ação associada à verificação do reCAPTCHA
    public string challenge_ts { get; set; } = string.Empty; // Timestamp(Data) do desafio do reCAPTCHA
    public string hostname { get; set; } = string.Empty; // Nome do host(Local) onde o reCAPTCHA foi executado

}
