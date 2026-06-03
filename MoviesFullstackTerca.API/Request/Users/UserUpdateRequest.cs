namespace MoviesFullstackTerca.API.Request.Users;

public class UserUpdateRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
