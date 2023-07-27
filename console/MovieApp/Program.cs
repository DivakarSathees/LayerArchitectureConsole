using System;
using System.Collections.Generic;

namespace MovieApp{
public class Program
{
    public static void Main(string[] args)
    {
        BusinessLayer businessLayer = new BusinessLayer();

        while (true)
        {
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Edit Movie");
            Console.WriteLine("3. Find Movies");
            Console.WriteLine("4. Delete Movie");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice (1-5):");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Movie newMovie = GetMovieDetailsFromUser();
                    businessLayer.AddMovie(newMovie);
                    Console.WriteLine("Movie added successfully!");
                    Console.WriteLine();
                    break;
                case "2":
                    List<Movie> allMovies = businessLayer.GetAllMovies();
                    Console.WriteLine("All Movies:");
                    PrintMovies(allMovies);
                    Console.WriteLine("Enter the ID of the movie to edit:");
                    if (int.TryParse(Console.ReadLine(), out int editId))
                    {
                        Movie movieToEdit = allMovies.Find(m => m.Id == editId);
                        if (movieToEdit != null)
                        {
                            Movie editedMovie = GetMovieDetailsFromUser();
                            editedMovie.Id = movieToEdit.Id;
                            businessLayer.EditMovie(editedMovie);
                            Console.WriteLine("Movie edited successfully!");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid movie ID.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid movie ID.");
                        Console.WriteLine();
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter a keyword to search for movies:");
                    string keyword = Console.ReadLine();
                    List<Movie> foundMovies = businessLayer.FindMovies(keyword);
                    Console.WriteLine($"Movies found for keyword '{keyword}':");
                    PrintMovies(foundMovies);
                    Console.WriteLine();
                    break;
                case "4":
                    List<Movie> moviesToDelete = businessLayer.GetAllMovies();
                    Console.WriteLine("All Movies:");
                    PrintMovies(moviesToDelete);
                    Console.WriteLine("Enter the ID of the movie to delete:");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        Movie movieToDelete = moviesToDelete.Find(m => m.Id == deleteId);
                        if (movieToDelete != null)
                        {
                            businessLayer.DeleteMovie(movieToDelete.Id);
                            Console.WriteLine("Movie deleted successfully!");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid movie ID.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid movie ID.");
                        Console.WriteLine();
                    }
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                    Console.WriteLine();
                    break;
            }
        }
    }

    private static Movie GetMovieDetailsFromUser()
    {
        Console.WriteLine("Enter Movie Title:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter Movie Genre:");
        string genre = Console.ReadLine();
        Console.WriteLine("Enter Movie Year:");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            return new Movie
            {
                Title = title,
                Genre = genre,
                Year = year
            };
        }
        else
        {
            Console.WriteLine("Invalid input. Year must be a numeric value.");
            return null;
        }
    }

    private static void PrintMovies(List<Movie> movies)
    {
        foreach (Movie movie in movies)
        {
            Console.WriteLine($"ID: {movie.Id}");
            Console.WriteLine($"Title: {movie.Title}");
            Console.WriteLine($"Genre: {movie.Genre}");
            Console.WriteLine($"Year: {movie.Year}");
            Console.WriteLine();
        }
    }
}
}