using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using tranhuuhuy_2011061565.Models;
namespace tranhuuhuy_2011061565.Controllers
{
    [System.Web.Mvc.Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _DbContext;

        public AttendancesController()
        {
            _DbContext = new ApplicationDbContext();
        }
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Attend ([FromBody] int courseId)
        {
            var userId =User.Identity.GetUserId();
            if (_DbContext.Attendances.Any(a=>a.AttendanceId == userId && a.CourseId == courseId ))
                return BadRequest("The Attendance exists!");
            var attendance = new Attendance
            {
                CourseId = courseId,
                AttendanceId = userId 
            };
            _DbContext.SaveChanges();
            _DbContext.Attendances.Add(attendance);

            return Ok();
        }
    }
}
