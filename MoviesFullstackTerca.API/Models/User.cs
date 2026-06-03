namespace MoviesFullstackTerca.API.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public User ()
    {

    }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
