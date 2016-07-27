using System.Linq;
using DbUpApplication.Model;

namespace DbUpApplication.UI
{
    public class Controller
    {
        private readonly View _view;
        private readonly string _connectionName;
        public Controller(string connectionName)
        {
            _connectionName = connectionName;
            _view = new View();
        }

        public void Start()
        {
            var exit = false;
            while (exit == false)
            {
                var mainMenuChoice = MainMenu();
                switch (mainMenuChoice)
                {
                    case MainMenuChoice.NewFilm:
                        NewFilm();
                        break;
                    case MainMenuChoice.UpdateFilm:
                        UpdateFilm();
                        break;
                    case MainMenuChoice.NewFilmRating:
                        NewFilmRating();
                        break;
                    case MainMenuChoice.ViewFilmRating:
                        ViewFilmRating();
                        break;
                    case MainMenuChoice.NewActor:
                        NewActor();
                        break;
                    case MainMenuChoice.AddActorToFilm:
                        AddActorToFilm();
                        break;
                    case MainMenuChoice.Exit:
                        exit = true;
                        break;
                }
            }
        }

        private MainMenuChoice MainMenu()
        {
            var mainMenuChoice = MainMenuChoice.None;
            while (mainMenuChoice == MainMenuChoice.None)
            {
                _view.WriteMainMenu();
                mainMenuChoice = _view.GetMainMenuChoice();
            }

            return mainMenuChoice;
        }

        private void NewFilm()
        {
            var newFilm = _view.GetNewFilmInfo();

            using (var db = new FilmDbContext(_connectionName))
            {
                db.Films.Add(newFilm);
                db.SaveChanges();
                _view.WriteFilmList(db.Films.ToList());
            }
        }

        private void UpdateFilm()
        {
            using (var db = new FilmDbContext(_connectionName))
            {
                var films = db.Films.ToList();
                var filmChoice = _view.GetFilmChoice(films);
                var newFilmInfo = _view.GetNewFilmInfo();
                filmChoice.Name = newFilmInfo.Name;
                filmChoice.Description = newFilmInfo.Description;
                filmChoice.Genre = newFilmInfo.Genre;

                db.SaveChanges();
            }
        }

        private void NewFilmRating()
        {
            using (var db = new FilmDbContext(_connectionName))
            {
                var films = db.Films.ToList();
                var filmChoice = _view.GetFilmChoice(films);
                var filmRating = _view.GetNewFilmRating();
                filmRating.Film = filmChoice;

                db.FilmRatings.Add(filmRating);
                db.SaveChanges();
            }
        }

        private void ViewFilmRating()
        {
            using (var db = new FilmDbContext(_connectionName))
            {
                var films = db.Films.ToList();
                var filmChoice = _view.GetFilmChoice(films);

                var ratings = db.FilmRatings.Where(x => x.FilmId == filmChoice.FilmId).ToList();

                _view.WriteFilmRatings(filmChoice, ratings);
            }
        }

        private void NewActor()
        {
            using (var db = new FilmDbContext(_connectionName))
            {
                var actor = _view.GetNewActor();
                db.Actors.Add(actor);
                db.SaveChanges();
            }
        }

        private void AddActorToFilm()
        {
            using (var db = new FilmDbContext(_connectionName))
            {
                var actor = _view.GetActorChoice(db.Actors.ToList());

                var film = _view.GetFilmChoice(db.Films.ToList());

                film.Actors.Add(actor);

                db.SaveChanges();
            }
        }
    }
}