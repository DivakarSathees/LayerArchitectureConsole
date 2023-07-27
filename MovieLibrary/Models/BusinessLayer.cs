using System;
using System.Collections.Generic;



public class BusinessLayer
{
    private readonly DataAccessLayer dataAccessLayer;

    public BusinessLayer()
    {
        dataAccessLayer = new DataAccessLayer();
    }

    public void AddMovie(Movie movie)
    {
        ValidateMovieData(movie);
        dataAccessLayer.AddMovie(movie);
    }

    public void EditMovie(Movie movie)
    {
        ValidateMovieData(movie);
        dataAccessLayer.EditMovie(movie);
    }

    public List<Movie> GetAllMovies()
    {
        return dataAccessLayer.GetAllMovies();
    }

    public List<Movie> FindMovies(string keyword)
    {
        return dataAccessLayer.FindMovies(keyword);
    }

    public void DeleteMovie(int movieId)
    {
        dataAccessLayer.DeleteMovie(movieId);
    }

    private void ValidateMovieData(Movie movie)
    {
        if (string.IsNullOrEmpty(movie.Title))
        {
            throw new ArgumentException("Title is required.");
        }

        if (string.IsNullOrEmpty(movie.Genre))
        {
            throw new ArgumentException("Genre is required.");
        }

        if (movie.Year <= 0)
        {
            throw new ArgumentException("Invalid year.");
        }
    }
}
