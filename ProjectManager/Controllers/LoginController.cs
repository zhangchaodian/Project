using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectManager.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        #region 登录验证
        public ActionResult LoginCheck()
        {
            string user=Request["user"];
            string pass=Request["pass"];
            string p_belongs=Request["p_belongs"];
            Session["p_belongs"] = p_belongs.Equals("a") ? "科研项目管理系统" : "质量工程项目管理系统";
            int result= BLL.UserInfoServer.CheckLogin(user,pass);
           

            if (result < 0)
            {
                return Content("登录失败！");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(user, false);
                BLL.UserInfoServer server = new BLL.UserInfoServer();
                Model.User u = server.getUserInfo(user,pass);
                 Session["userinfo"] = u;
               //a代表管理员 b用户
                if (result == 0)
                {
                    Session["u_type"] = "教职工";
                    return Redirect("/usermanager/");
                }
                else
                {
                    Session["Identity"] = "admin";
                    return Redirect("/usermanager");
                }
            }

        }
        #endregion


        #region 
        public void Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
        #endregion
    }
}
