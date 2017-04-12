using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieApp.Dtos;
using MovieApp.Models;

namespace MovieApp.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //We are creating an object or data in database.

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            var customer = _context.Customers
                 .Single(c => c.Id == newRental.CustomerId);

            //if(customer==null)
            //    return BadRequest("Customer Id is not Valid");

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            //if(newRental.MovieIds.Count==0)
            //    return BadRequest("No movies");

            foreach (var movie in movies)
            {
                // check the movie stock condition
                if(movie.NumberAvailabel==0)
                    return BadRequest("Movie is not available");

                //reducing the stock of movie when it is rented
                movie.NumberAvailabel--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                //inserting data into Rentals Database.
                _context.Rentals.Add(rental);
            }

            //saving the changes, a new record created.
            _context.SaveChanges();

            return Ok();
        }
    }
}
