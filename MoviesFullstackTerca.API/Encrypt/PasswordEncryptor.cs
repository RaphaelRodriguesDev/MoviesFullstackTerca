using System.Security.Cryptography;
using System.Text;

namespace MoviesFullstackTerca.API.Encrypt;

public static class PasswordEncryptor
{
    public static string EncryptPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException(nameof(password), "Password cannot be null or empty.");
        }

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword) {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
        {
            return false;
        }

        string encryptedInput = EncryptPassword(password);
        return encryptedInput == hashedPassword;
    }
}
