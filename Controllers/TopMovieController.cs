using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using xysim_moviedb.Data;
using xysim_moviedb.Models;

namespace xysim_moviedb.Controllers
{
    public class TopMovieController : Controller
    {
        private TopRatedMovieRepository _TopRatedMovieRepository = null;

        public TopMovieController()
        {
            _TopRatedMovieRepository = new TopRatedMovieRepository();
        }

        public ActionResult Movie()
        {
            var movies = _TopRatedMovieRepository.GetMovies();
            
            return View(movies);
        }

    }
}