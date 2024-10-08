﻿using G_MovieStoreMVC.Models.Entity;

namespace G_MovieStoreMVC.Models.DTO
{
    public class MovieListVM
    {
        public IQueryable<Movie> MovieList { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
