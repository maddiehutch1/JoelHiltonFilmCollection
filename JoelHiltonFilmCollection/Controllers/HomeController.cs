using Mission06_MadHutchings.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JoelHiltonFilmCollection.Controllers 
{
    // Here is the main controller used to connect the app to all the views and Get/Post actions
    public class HomeController : Controller
    {
        private MovieEntryContext _movieEntryContext;
        public HomeController(MovieEntryContext temp) // constructor... makes an instance of movie class
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

        // DISPLAY MOVIE FILL OUT FORM - this is connected to the form being submitted
        // and what takes place, and the ModelState.IsValid checks all the
        // validation attributes on the model
        [HttpGet]
        public IActionResult MovieCollForm()
        {
            ViewBag.categories = _movieEntryContext.Categories
                .OrderBy(c => c.CategoryName).ToList();

            return View(new MovieEntry());
        }

        [HttpPost]
        public IActionResult MovieCollForm(MovieEntry response)
        {
            // Check if LentTo field is null and set it to an empty string if true
            // (stop errors from happening)
            response.LentTo = response.LentTo ?? "";

            if (ModelState.IsValid)
            {

                _movieEntryContext.Movies.Add(response);
                _movieEntryContext.SaveChanges();

                return View("SuccessPage", response);
            }
            else // invalid data - return invalid messages
            {

                ViewBag.categories = _movieEntryContext.Categories
                    .OrderBy(c => c.CategoryName).ToList();
            }

            return View(response);
        }

        // DISPLAY MOVIE TABLE
        public IActionResult MovieTable()
        {
            var movieEntries = _movieEntryContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();

            return View(movieEntries);
        }

        // For both "EDIT" and "DELETE" actions, it involves a single record to be analyzed based on ID and
        // the ViewBag is also pulled in (for Categories)
        // Make sure the values are updated and saved
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _movieEntryContext.Movies
                .Single(x => x.MovieId == id);

            ViewBag.categories = _movieEntryContext.Categories
                    .OrderBy(c => c.CategoryName).ToList();

            return View("MovieCollForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(MovieEntry updatedInfo)
        {
            _movieEntryContext.Update(updatedInfo);
            _movieEntryContext.SaveChanges();
            
            return RedirectToAction("MovieTable"); // redirect to the action of MovieTable HTTP post
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _movieEntryContext.Movies
                .Single(x => x.MovieId == id);

            ViewBag.categories = _movieEntryContext.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();

            return View("Delete", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieEntry deletedInfo)
        {
            _movieEntryContext.Movies.Remove(deletedInfo);
            _movieEntryContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }

    }
}
