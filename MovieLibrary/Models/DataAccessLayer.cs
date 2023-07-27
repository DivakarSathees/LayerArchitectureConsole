using System;
using System.Collections.Generic;


public class DataAccessLayer
{
    private List<Movie> movies;

    public DataAccessLayer()
    {
        movies = new List<Movie>();
    }

    public void AddMovie(Movie movie)
    {
        int newId = GetNextId();
        movie.Id = newId;
        movies.Add(movie);
    }

    public void EditMovie(Movie movie)
    {
        Movie existingMovie = movies.Find(m => m.Id == movie.Id);
        if (existingMovie != null)
        {
            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.Year = movie.Year;
        }
        else
        {
            throw new ArgumentException("Movie not found.");
        }
    }

    public List<Movie> GetAllMovies()
    {
        return movies;
    }

    public List<Movie> FindMovies(string keyword)
    {
        return movies.FindAll(movie =>
            movie.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
            movie.Genre.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
    }

    public void DeleteMovie(int movieId)
    {
        Movie movie = movies.Find(m => m.Id == movieId);
        if (movie != null)
        {
            movies.Remove(movie);
        }
        else
        {
            throw new ArgumentException("Movie not found.");
        }
    }

    private int GetNextId()
    {
        return movies.Count + 1;
    }
}