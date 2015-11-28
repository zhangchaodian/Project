using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Model;

namespace ProjectManager.Controllers.User
{
    [Authorize]
    public class UserManagerController : Controller
    {
        //
        // GET: /UserManager/
    List<DAL.getDefaultProject_Result> projectInfo =new  List<DAL.getDefaultProject_Result>();
    
    

#region 登录后进入的首个页面
[Authorize]
public ActionResult index()
    {
        Model.userinfo userInfo = (userinfo)Session["userinfo"];
        ViewBag.UserInfo = userInfo;
       // ViewBag.user = User.Identity.Name; 
        projectInfo = DAL.ProjectInfoDAL.getProject_pass_Info();
        //projectInfo = (from rerult in projectInfo where (rerult.remark.Equals("审核一") && rerult.p_rank.Equals("国家级")) select rerult).ToList();
        ViewBag.ProjectInfo = projectInfo;
        return View();
    }
    #endregion

        /*
    public ActionResult index()
    {
        string str1 = Request.Form["updownorder1"];
        string str2 = "国家级";
        string str3 = Request.Form["updownorder3"];
        string str4 = "p_id";
        string str5 = "asc";
        projectInfo = DAL.ProjectInfoDAL.getProject_pass_Info();
        projectInfo = BLL.ProjectServer.getSearchResult(projectInfo, str2, str4, str5);
        string htmlstr = BLL.ProjectServer.getJsonHtml(projectInfo);
        // string tbody = "<tr><td>1</td><td>思科</td><td>IT</td><td>某某某项目</td><td>张朝钿</td><td>审核一</td><td>国家级</td><td>2015-10-29</td></tr>".ToString();
        return Content(htmlstr);
    }
         * */
        #region  搜索处理1，返回json数据
        public JsonResult GetSearch()
        {
            string str1 = Request.Form["updownorder1"];
            string str2 = Request.Form["updownorder2"];//项目级别
            string str3 = Request.Form["updownorder3"];
            string str4 = Request.Form["updownorder4"];
            string str5 = Request.Form["updownorder5"];
            projectInfo = DAL.ProjectInfoDAL.getProject_pass_Info();
            projectInfo=BLL.ProjectServer.getSearchResult(projectInfo,str2,str4,str5);
            string htmlstr = BLL.ProjectServer.getJsonHtml(projectInfo);
           // string tbody = "<tr><td>1</td><td>思科</td><td>IT</td><td>某某某项目</td><td>张朝钿</td><td>审核一</td><td>国家级</td><td>2015-10-29</td></tr>".ToString();
            return Json(htmlstr, JsonRequestBehavior.AllowGet);

            


        }
        #endregion

        #region 搜索处理2，返回json数据
        public JsonResult GetSearch2()
        {
            string keyword_type = Request.Form["updownorder1"];
            string keyword = Request.Form["updownorder2"];//项目级别
           // string tbody = "<tr><td>1</td><td>思科</td><td>IT</td><td>某某某项目</td><td>张朝钿</td><td>审核一</td><td>国家级</td><td>2015-10-29</td></tr>".ToString();
            projectInfo = DAL.ProjectInfoDAL.getProject_pass_Info();
            projectInfo=BLL.ProjectServer.getSearchResult2(projectInfo,keyword_type,keyword);
            string htmlstr = BLL.ProjectServer.getJsonHtml(projectInfo);
            return Json(htmlstr, JsonRequestBehavior.AllowGet);
        }
        #endregion



        [Authorize]
        public ActionResult Project_Schedule_Each()
        {
            ViewBag.user = User.Identity.Name;
          
            return View("Project_Schedule_Each");
        }
        [Authorize]
        public ActionResult Project_Schedule()
        {
            ViewBag.user = User.Identity.Name;
            List<Model.Project_Schedule_Model> s_model = new List<Project_Schedule_Model>();
            s_model = BLL.ProjectServer.getScheduleModel();
            ViewBag.s_model = s_model;
            return View("Project_Schedule");
        }
        [Authorize]
        public ActionResult Personal_Project()
        {
            ViewBag.user = User.Identity.Name; 
            return View("Personal_Project");
        }
        [Authorize]
        public ActionResult Project_Declare()
        {
            ViewBag.user = User.Identity.Name;
            return View("Project_Declare");
        }
        [Authorize]
        public ActionResult Personal_Project_Abled()
        {
            ViewBag.user = User.Identity.Name; 
            return View("Personal_Project_Abled");
        }
        [Authorize]
        public ActionResult Personal_Project_Disabled()
        {
            ViewBag.user = User.Identity.Name; 
            return View("Personal_Project_Disabled");
        }
}
}

