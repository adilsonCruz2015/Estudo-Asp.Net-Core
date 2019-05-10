﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Genre { get; set; }
        
        public DateTime ReleaseDate { get; set; }
    }
}
