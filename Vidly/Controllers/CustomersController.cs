using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Database;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private MyContext _context;

        public CustomersController()
        {
            _context = new MyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var movie = new Movie() { Name = "Poseidon" };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes =  membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewCustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModelInController = new NewCustomerViewModel
                {
                    Customer = viewModel.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("New", viewModelInController);
            }

            if (viewModel.Customer.Id == 0)
            {
                _context.Customers.Add(viewModel.Customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);
                var customerFromView = viewModel.Customer;

                customerInDb.Name = customerFromView.Name;
                customerInDb.Surname = customerFromView.Surname;
                customerInDb.Birthdate = customerFromView.Birthdate;
                customerInDb.IsSubscribedToNewsLetter = customerFromView.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customerFromView.MembershipTypeId;
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }
    }
}