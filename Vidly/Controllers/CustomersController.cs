using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ViewResult Index()
        {
            var movie = new Movie() { Name = "Poseidon" };
            var customers = new List<Customer>
            {
                new Customer() {Name =  "Maciej", Surname = "Garncarz", Id = 1},
                new Customer() {Name =  "Patrycja", Surname = "Biegun", Id = 2},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
        }

        public ViewResult Detail(int id)
        {
            var customers = new List<Customer>
            {
                new Customer() {Name =  "Maciej", Surname = "Garncarz", Id = 1},
                new Customer() {Name =  "Patrycja", Surname = "Biegun", Id = 2},
            };

            var customerToReturn = customers.SingleOrDefault(x => x.Id == id);

            return View(customerToReturn);
        }
    }
}