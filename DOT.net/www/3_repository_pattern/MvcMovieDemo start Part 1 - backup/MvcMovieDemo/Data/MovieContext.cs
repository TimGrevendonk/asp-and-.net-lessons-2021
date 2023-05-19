﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovieDemo.Models;

namespace MvcMovieDemo.Data
{
    //STAP 1: CONTEXT KLASSE AANMAKEN
    //VOOR ELKE KLASSE/ENTITEIT EEN DBSET AANMAKEN
    //VOOR ELKE KLASSE/ENTITEIT EEN TABEL LATEN GENEREREN
    public class MovieContext: DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Rating>().ToTable("Rating");
        }
    }

}

