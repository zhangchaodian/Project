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
            int result= BLL.UserInfoServer.CheckLogin(user,pass);
            DAL.Login lo = new DAL.Login();

            if (result < 0)
            {
                return Content("登录失败！");
            }
            else
            {
               /* Response.Cookies["user"].Value = user;
                Response.Cookies["user"].Expires = DateTime.Now.AddDays(1);
                * */
                FormsAuthentication.SetAuthCookie(user, false);
                Session["userinfo"] = BLL.UserInfoServer.getUser(user,pass);
               //0代表管理员 1用户
                if (result == 0)
                {
                    Session["Identity"] = "admin";
                    return Redirect("/usermanager/");
                }
                else
                {
                    Session["Identity"] = "user";
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
