using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tranhuuhuy_2011061565.Models;

namespace tranhuuhuy_2011061565.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}