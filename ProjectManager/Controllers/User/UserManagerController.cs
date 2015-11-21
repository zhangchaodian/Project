using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers.User
{
    public class UserManagerController : Controller
    {
        //
        // GET: /UserManager/

        public ActionResult Index()
        {
            return View("Project_Schedule_Each");
        }
        public ActionResult Project_Schedule()
        {
            return View("Project_Schedule");
        }
        public ActionResult Personal_Project()
        {
            return View("Personal_Project");
        }
        public ActionResult declare()
        {
            return View("declare");
        }
        public ActionResult Personal_Project_Abled()
        {
            return View("Personal_Project_Abled");
        }
        public ActionResult Personal_Project_Disabled()
        {
            return View("Personal_Project_Disabled");
        }
    }
}
