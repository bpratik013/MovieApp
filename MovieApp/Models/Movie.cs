﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name="Number in Stock")]
        [Range(1,20)]
        public int Stock { get; set; }

        public byte NumberAvailabel { get; set; }

        
        public Genre Genre { get; set; }

        [Required]
        [Display(Name="Genre")]
        public int GenreId { get; set; }

    }
}