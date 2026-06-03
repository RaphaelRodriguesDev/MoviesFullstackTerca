namespace MoviesFullstackTerca.API.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string PosterUrl { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;

    public Movie()
    {

    }

    public Movie(string title, string posterUrl, string overview)
    {
        Title = title;
        PosterUrl = posterUrl;
        Overview = overview;
    }
}
