﻿using Common.GenericRepository;
using Infrastructure.DataContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class MoviesRepository : GenericRepository<Movie>, IMoviesRepository
    {
        public MoviesRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Movie> GetAllFeatureMovies()
        {
            return _dbContext.Movies.Where(t => t.IsSeriesMovie == false).OrderBy(t => t.CreatedDate).ToList();
        }

        public ICollection<Movie> GetAllMovieHot()
        {
            return _dbContext.Movies.Where(t => t.IsHot == true).OrderBy(t => t.CreatedDate).ToList();
        }

        public ICollection<Movie> GetAllSeriesTV()
        {
            return _dbContext.Movies.Where(t => t.IsSeriesMovie == true).OrderBy(t => t.CreatedDate).ToList();
        }

        public ICollection<Movie> GetCountFeatureFilm(int countMovie)
        {
            return _dbContext.Movies.Where(t => t.IsSeriesMovie == false).OrderBy(t => t.CreatedDate).Take(countMovie).ToList();
        }

        public ICollection<Movie> GetCountMovieHot(int countMovie)
        {
            return _dbContext.Movies.Where(t => t.IsHot == true).OrderBy(t => t.CreatedDate).Take(countMovie).ToList();
        }

        public ICollection<Movie> GetCountSeriesMovies(int countMovie)
        {
            return _dbContext.Movies.Where(t => t.IsSeriesMovie == true).OrderBy(t => t.CreatedDate).Take(countMovie).ToList();
        }

        public ICollection<Movie> GetMoviesByCategoryId(Guid id)
        {
            var listCategoryMovie = _dbContext.GetCategoryMovies.
                                        Where(t => t.CategoryId == id).Select(t => t.MovieId).ToList();
            return _dbContext.Movies.Where(t => listCategoryMovie.Contains(t.Id)).OrderBy(t => t.CreatedDate).ToList();
        }

        public ICollection<Movie> GetNewestMovies(int countMovie)
        {
            return _dbContext.Movies.OrderBy(t => t.CreatedDate).Take(countMovie).OrderBy(t => t.CreatedDate).ToList();
        }

        public ICollection<Movie> SearchMovieByName(string name)
        {
            return _dbContext.Movies.Where(t => t.Name.Contains(name)).OrderBy(t => t.CreatedDate).ToList();
        }

        public ICollection<Movie> SearchMovieByNameAndType(string name, bool isSeriesTV)
        {
            return _dbContext.Movies.Where(t => t.Name.Contains(name) && t.IsSeriesMovie == isSeriesTV).OrderBy(t => t.CreatedDate).ToList();
        }

        public ICollection<Movie> SearchMoviesByKeyWord(string keyword)
        {
            while (keyword.Contains("  "))
            {
                keyword = keyword.Replace("  ", " ");
            }
            var listKeywords = keyword.Split(' ');
            var listMovie = new List<Movie>();

            foreach (var item in listKeywords)
            {
                listMovie = listMovie.Union(_dbContext.Movies.Where(t => t.Name.Contains(item)))
                    .Union(_dbContext.Movies.Where(t => t.NameEn.Contains(item)))
                    .OrderBy(t => t.CreatedDate)
                    .ToList();
            }

            return listMovie;
        }
    }
}
