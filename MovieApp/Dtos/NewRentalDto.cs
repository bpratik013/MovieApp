using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieApp.Models;

namespace MovieApp.Dtos
{
    public class NewRentalDto
    {
        // A single customer can add multiple movies
        public int CustomerId { get; set; }

        //Add multiple movies ID
        public List<int> MovieIds { get; set; }
    }
}