﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using tranhuuhuy_2011061565.Models;
using tranhuuhuy_2011061565.ViewModels;
using System.Data.Entity;

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
        [Authorize]

        public ActionResult Create()
        {
            var ViewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
            };
            return View(ViewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories= _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
               LecturerId= User.Identity.GetUserId(),
               DateTime= viewModel.GetDateTime(),
               CategoryId= viewModel.Category,
               Place= viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();   
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .Include(l => l.Lecturer)
                .Include(l => l.Category)
                .ToList();
            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = course,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
    }
}