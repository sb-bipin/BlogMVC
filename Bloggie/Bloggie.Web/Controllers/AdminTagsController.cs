using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewMOdels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        

        private readonly BloggieDbContext bloggieDbContext;

        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(addTagRequest);
            }

            //mapping addTagRequest to tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName

            };

            try
            {
                bloggieDbContext.Tags.Add(tag);
                bloggieDbContext.SaveChanges();
                return View("Add");
            }
            catch (Exception ex)
            {
                LoggerMessage(ex, $"An error occurred while saving data to the database.");
                Console.WriteLine(ex);

                return View("Error");
            }
        }

        private void LoggerMessage(Exception ex, string v)
        {
            throw new NotImplementedException();
        }
    }
}
