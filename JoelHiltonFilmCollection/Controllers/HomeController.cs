using Mission06_MadHutchings.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SQLitePCL;

namespace JoelHiltonFilmCollection.Controllers // forgive me for changing the name of file... it looked better on website with this namespace
                                               // instead of Mission6 with my name haha
{
    // Here is the main controller used to connect the app to all the views
    public class HomeController : Controller
    {
        private MovieEntryContext _movieEntryContext;
        public HomeController(MovieEntryContext temp) // constructor
        {
            _movieEntryContext = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieCollForm()
        {
            return View();
        }

        // this is connected to the form being submitted and what takes place
        [HttpPost]
        public IActionResult MovieCollForm(MovieEntry response)
        {
            // Check if LentTo and Notes fields are null and set them to an empty string if true
            response.Notes = response.Notes ?? "";
            response.LentTo = response.LentTo ?? "";

            if (ModelState.IsValid)
            {
                // The ModelState.IsValid checks all the validation attributes on the model

                _movieEntryContext.Movies.Add(response); // add record into database if no issues
                _movieEntryContext.SaveChanges();

                return View("SuccessPage", response);
            }

            // If ModelState is not valid, it means there are validation errors
            // Return to the view with the validation errors
            return View(response);
        }

        public IActionResult MovieTable()
        {
            var movieEntries = _movieEntryContext.Movies
                .OrderBy(x => x.Title).ToList();

            return View(movieEntries);
        }

    }
}
