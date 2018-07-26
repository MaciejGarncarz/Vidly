using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Database;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MyContext _context;

        public MoviesController()
        {
            _context = new MyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(g => g.Genre).ToList();
            var customers = new List<Customer>
            {
                new Customer() {Name =  "Maciej"},
                new Customer() {Name =  "Patrycja"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movies = movies,
                Customers = customers
            };

            return View(viewModel);
        }

        public ViewResult Detail(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(NewMovieViewModel viewModel)
        {
            var movieFromView = viewModel.Movie;


            if (movieFromView.Id == 0)
            {
                _context.Movies.Add(movieFromView);
            }
            else
            {
                var movieFromDb = _context.Movies.Single(m => m.Id == movieFromView.Id);
                movieFromDb.Name = movieFromView.Name;
                movieFromDb.ReleaseDate = movieFromView.ReleaseDate;
                movieFromDb.GenreId = movieFromView.GenreId;
                movieFromDb.NumberInStock = movieFromView.NumberInStock;
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("New", viewModel);
        }
    }
}