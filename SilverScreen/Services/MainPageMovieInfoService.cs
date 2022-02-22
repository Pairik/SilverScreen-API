﻿using Microsoft.Extensions.Configuration;
using SilverScreen.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverScreen.Services
{
    public class MainPageMovieInfoService
    {
        /// <summary>
        /// This metod takes all movies based on a specific genre.
        /// </summary>
        /// <param name="genre">Take movies based on the genre you have chosen.</param>
        /// <returns>Returns list of movies by genre.</returns>
        public List<Movie> GetMoviesByGenre(int genre)
        {
            SilverScreenContext context = new SilverScreenContext();
            List<MovieGenre> movieGenres = new List<MovieGenre>();
            List<Movie> movies = new List<Movie>();
            using (context)
            {

                movieGenres = context.MovieGenres.Where(s => s.GenreId == genre).ToList();
                foreach (var movieGenre in movieGenres)
                {
                    movies.Add(context.Movies.Where(s => s.Id == movieGenre.MovieId).FirstOrDefault());
                }
                return movies;

            }

        }
        /// <summary>
        /// This method takes a user's movies and put them in list to see if they have been watched or are for watching.
        /// </summary>
        /// <param name="userID">Takes a user id.</param>
        /// <param name="watched">Takes by true or false with movie is watched.</param>
        /// <returns>Returns list of movies based on with have been watched or are for watching.</returns>
        public List<Movie> GetMyListMovies(int userID, bool watched)
        {
            SilverScreenContext context = new SilverScreenContext();
            List<MyList> myListMovies = new List<MyList>();
            List<Movie> movies = new List<Movie>();
            using (context)
            {
                myListMovies = context.MyLists.Where(s => s.UserId == userID && s.Watched == watched).ToList();
                foreach (var myListMovie in myListMovies)
                {
                    movies.Add(context.Movies.Where(s => s.Id == myListMovie.MovieId).FirstOrDefault());
                }                  
                return movies;

            }

        }
        /// <summary>
        /// This metod takes the movies and search them by title.
        /// </summary>
        /// <param name="searchString">The string based on which the searh is performed.</param>
        /// <returns>Returns a list that contains all movies with that title.</returns>
        public List<Movie> SearchMovieByTitle(string searchString)
        {
            SilverScreenContext context = new SilverScreenContext();
            List<Movie> searchMovies = new List<Movie>();
            using (context)
            {
                searchMovies = context.Movies.Where(s => s.Title.Contains(searchString)).ToList();
            }
            return searchMovies;
        }
    }
}
