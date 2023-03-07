using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranhuuhuy_2011061565.Models;
using tranhuuhuy_2011061565.ViewModels;

namespace tranhuuhuy_2011061565.Controllers
{
    
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext= new ApplicationDbContext();
        }
        // GET: Courses
        public ActionResult Create()
        {
            var ViewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
            };
            return View(ViewModel);
        }
    }
}