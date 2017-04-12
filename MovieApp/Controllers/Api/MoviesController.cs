using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieApp.Dtos;
using MovieApp.Models;
using AutoMapper;

namespace MovieApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable GetMovies(string query)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailabel > 0);

            return moviesQuery
                .Where(m => m.Name.Contains(query))
                .ToList();
        }
        //get /api/customers
        //public IHttpActionResult GetMovies()
        //{
        //    //Delegate to the customer object. by using Mapper 
        //    var movieDto = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);

        //    return Ok(movieDto);
        //}

        //get /api/customers/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }

        //post /api/customer
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //put/api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieinDB = _context.Movies.Single(m => m.Id == id);

            if (movieinDB == null)
                return NotFound();
            Mapper.Map(movieDto, movieinDB);


            _context.SaveChanges();

            return Ok();
        }

        //Delete/api/customer/1

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = _context.Movies.Single(c => c.Id == id);
            if (movie == null)
                return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();

        }
    }
}
