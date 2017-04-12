using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;
using System.Data.Entity;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genre
            };
            
            return View("MovieForm",viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);

            else
            {
                //updating the movie data in the same action
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded=movie.DateAdded;
                movieInDb.Stock=movie.Stock;
                movieInDb.GenreId = movie.GenreId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .ToList();

            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            if(movie==null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()

            };

                
            return View("MovieForm",viewModel);
        }
    }
}