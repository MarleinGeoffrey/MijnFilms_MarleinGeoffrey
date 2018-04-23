using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MijnFilms_MarleinGeoffrey.Entities;


namespace MijnFilms_MarleinGeoffrey.Controllers
{
    
    [Route("")]
    public class MoviesController : Controller
    {
        MoviesBaseContext db;
        public MoviesController()
        {
            db = new MoviesBaseContext();
        }
        [Route("")]
        [Route("[controller]/[action]")]
        public IActionResult Lijst()
        {
            return View(db.Movie.Select(a => a).ToList());
        }

        [HttpGet]
        [Route("[controller]/[action]/{MovieId:int}")]
        public IActionResult Details(int MovieId)
        {
            
            Movie movieDetails = db.Movie.Where(s => s.MovieId == MovieId).Select(c => c).SingleOrDefault();
            if(movieDetails == null)
            {
                return View("Lijst", db.Movie.Select(a => a).ToList());
            }
            else
            {
                Genre genre = db.Genre.Where(s => s.GenreId == movieDetails.GenreId).Select(c => c).SingleOrDefault();
                Person director = db.Person.Where(c => c.PersonId == movieDetails.DirectorId).SingleOrDefault();
                ViewBag.Genre = genre.Description;
                ViewBag.Director = director.FirstName + " " + director.LastName;
                return View(movieDetails);
            }

            
        }

        
        [Route("[action]/{SorteerValue}")]
        [Route("[controller]/[action]/{SorteerValue}")]
        public IActionResult Sorteer(string SorteerValue)
        {
            switch (SorteerValue)
            {
                case "title":
                    return View("Lijst", db.Movie.OrderBy(c => c.Title).Select(a => a).ToList());
                case "year":
                    return View("Lijst", db.Movie.OrderByDescending(c => c.Year).OrderBy(c => c.Title).Select(a => a).ToList());
                case "stars":
                    return View("Lijst", db.Movie.OrderByDescending(c => c.Stars).OrderBy(c => c.Title).Select(a => a).ToList());
            }
            return View("Lijst", db.Movie.Select(a => a).ToList());
        }
    }
}