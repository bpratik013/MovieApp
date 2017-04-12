using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MovieApp.Dtos;
using MovieApp.Models;

namespace MovieApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomers(string query = null)
        {
            //filerting the query dynamically
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }
        ////get /api/customers
        //public IHttpActionResult GetCustomers()
        //{
        //    //Delegate to the customer object. by using Mapper 
        //    var customerDto = _context.Customers
        //        .Include(c=>c.MembershipType)
        //        .ToList()
        //        .Select(Mapper.Map<Customer, CustomerDto>);

        //    return Ok(customerDto);
        //}

        //get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }

        //post /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //put/api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerinDB = _context.Customers.Single(m => m.Id == id);

            if (customerinDB == null)
                return NotFound();

            Mapper.Map(customerDto, customerinDB);


            _context.SaveChanges();

            return Ok();

        }

        //Delete/api/customer/1

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = _context.Customers.Single(c => c.Id == id);
            if (customer == null)
                return NotFound();
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok();

        }
    }
}
