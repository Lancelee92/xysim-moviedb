using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using xysim_moviedb.Data;
using xysim_moviedb.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace xysim_moviedb.Controllers
{
    public class TopMovieController : Controller
    {
        private TopRatedMovieRepository _TopRatedMovieRepository = null;
/*
        public TopMovieController()
        {
            _TopRatedMovieRepository = new TopRatedMovieRepository();
        }
 */

        private readonly MvcMovieContext _context;

        public TopMovieController(MvcMovieContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Movie()
        {
            var movies = from m in _context.Movie select m;
            //var mdata;
            //if(moviedata == "null" || moviedata == "undefined"){
                //mdata = movies; 
                //var movies = _TopRatedMovieRepository.GetMovies();
                //Console.WriteLine(movies.GetType());                   
            //} 
            //movies = movies.Where(s => s.popularity > 50).Take(10);
            movies = movies.OrderByDescending(p => p.popularity).Take(10);
            var selectedMovies = await movies.ToListAsync();
            
            return View(selectedMovies);
        }

    }
}