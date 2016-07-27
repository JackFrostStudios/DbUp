using System;
using System.Collections.Generic;
using DbUpApplication.Model;

namespace DbUpApplication.UI
{
    public enum MainMenuChoice
    {
        NewFilm,
        UpdateFilm,
        NewFilmRating,
        ViewFilmRating,
        Exit,
        None
    }
    public class View
    {
        public void WriteMainMenu()
        {
            Console.WriteLine("Please type an option:");
            Console.WriteLine("1 - Enter New Film");
            Console.WriteLine("2 - Update Film");
            Console.WriteLine("3 - Add Film Rating");
            Console.WriteLine("4 - View Film Rating");
            Console.WriteLine("x - Exit");
        }

        public MainMenuChoice GetMainMenuChoice()
        {
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    return MainMenuChoice.NewFilm;
                case "2":
                    return MainMenuChoice.UpdateFilm;
                case "3":
                    return MainMenuChoice.NewFilmRating;
                case "4":
                    return MainMenuChoice.ViewFilmRating;
                case "x":
                    return MainMenuChoice.Exit;
                default:
                    return MainMenuChoice.None;
            }
        }

        public Film GetNewFilmInfo()
        {
            Console.WriteLine("Please type the film name:");
            var filmName = Console.ReadLine();
            Console.WriteLine("Please type the film description: ");
            var filmDescription = Console.ReadLine();
            Console.WriteLine("Please type the film genre:");
            var filmGenre = Console.ReadLine();

            return new Film
            {
                Name = filmName,
                Description = filmDescription,
                Genre = filmGenre
            };
        }

        public Film GetFilmChoice(List<Film> films)
        {
            Console.WriteLine("Please type a film number:");
            WriteFilmList(films);
            var choice = int.Parse(Console.ReadLine());

            return films[choice];
        }

        public void WriteFilmList(List<Film> films)
        {
            for (var i = 0; i < films.Count; i++)
            {
                Console.WriteLine("****************************");
                Console.WriteLine("{0} - ID: {1} \nFilm Name: {2} \nFilm Desctiption: {3}", i, films[i].FilmId, films[i].Name, films[i].Description);
                Console.WriteLine("****************************");
            }
        }

        public FilmRating GetNewFilmRating()
        {
            Console.WriteLine("Please type the film rating:");
            var filmRating = int.Parse(Console.ReadLine());
            Console.WriteLine("Please type a comment: ");
            var comment = Console.ReadLine();

            return new FilmRating
            {
                Rating = filmRating,
                Comment = comment
            };
        }

        public void WriteFilmRatings(Film film, List<FilmRating> ratings)
        {
            var averageRatingText = "No Ratings yet for this film.";
            if (ratings.Count != 0)
            {
                var averageRating = 0;
                ratings.ForEach(x => averageRating += x.Rating);
                averageRating = averageRating / ratings.Count;
                averageRatingText = "Average Rating: " + averageRating;
            }

            Console.WriteLine("**************FILM DETAILS**************");
            Console.WriteLine("ID: {0} \nFilm Name: {1} \nFilm Desctiption: {2}", film.FilmId, film.Name, film.Description);
            Console.WriteLine(averageRatingText);
            Console.WriteLine("****************************\n");

            if (ratings.Count == 0) return;

            Console.WriteLine("**************RATING DETAILS**************");
            ratings.ForEach(x =>
            {
                Console.WriteLine("____________________________");
                Console.WriteLine("ID: {0} \nRating: {1} \nComment: {2}", x.FilmRatingId, x.Rating, x.Comment);
                Console.WriteLine("____________________________");
            });
            Console.WriteLine("****************************\n");
        }
    }
}