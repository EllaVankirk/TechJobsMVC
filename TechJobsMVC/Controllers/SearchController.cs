using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        [Route("/search")]
        public IActionResult Index()
        {
            ViewBag.jobs = new List<Job>();
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view.
        [HttpPost]
        [Route("/search/results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            if (searchTerm == null || searchTerm == "")
            {
                jobs = JobData.FindAll();
            }
            else if (searchType.ToLower() == "all")
            {
                jobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType.ToLower(), searchTerm);
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;

            return View("Index");
        }

    }
}
