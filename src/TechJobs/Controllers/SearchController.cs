using System;           //line added by me
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();
     

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;

            List<Dictionary<String, String>> searchResults;

            // Fetch results
            if (searchType.Equals("all"))
            {
                
                searchResults = JobData.FindByValue(searchTerm);
             
            }
            else
            {
                searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
               
            }

            //List<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.title = "Jobs with " + ListController.columnChoices[searchType] + ": " + searchTerm;
            ViewBag.jobs = searchResults;

            return View("Index");
        }

    }
}
