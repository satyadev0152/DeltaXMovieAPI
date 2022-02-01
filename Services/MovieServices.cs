using MovieAPI.Models;

namespace MovieAPI.Services;

public static class MovieServices
{
    static List<Movie> Movies { get; }
    static int nextId = 3;
    static MovieServices()
    {
        Movies = new List<Movie>
        {
            new Movie { Id = 1, MovieName = "Interstellar", ActorName = "Matthew McConaughey", ProducerName = "Christopher Nolan" },
            new Movie { Id = 2, MovieName = "Baahubali: The Beginning", ActorName = "Prabhas", ProducerName = "Shobu Yarlagadda" },
            
        };
    }

    public static List<Movie> GetAll() => Movies;

    public static Movie? Get(int id) => Movies.FirstOrDefault(p => p.Id == id);

    public static void Add(Movie movie)
    {
        movie.Id = nextId++;
        Movies.Add(movie);
    }

    public static void Delete(int id)
    {
        var movie = Get(id);
        if(movie is null)
            return;

        Movies.Remove(movie);
    }

    public static void Update(Movie movie)
    {
        var index = Movies.FindIndex(p => p.Id == movie.Id);
        if(index == -1)
            return;

        Movies[index] = movie;
    }
}