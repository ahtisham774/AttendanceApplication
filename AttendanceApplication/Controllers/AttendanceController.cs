using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceApplication.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: AttendanceApi
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ClassAttendance()
        {
            
            return View(); 
        }
    }
}