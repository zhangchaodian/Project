using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DAL;
using ProjectManager.Model;

namespace ProjectManager.BLL
{
   public class UserInfoServer
   {
       #region 登录匹配
       public static int CheckLogin(string username,string pwd)
       {
           Login lo = new Login();
           List<Check_Login_Result> user ;
           user = lo.Check(username,pwd);//获取用户数据
           if (user.Count() > 0)
           {
               string usertype=(from u in user select u.userType).First();
               if(usertype.Equals("admin")){
                   return 0;
               }
               else{
                   return 1;
               }
           }
           else
           {
               return -1;
           }
       }
       #endregion


       #region 获取用户数据
       public static userinfo getUser(string name,string pass){
           DAL.UserInfoDAL info = new DAL.UserInfoDAL();
           Model.userinfo user= info.GetUserInfo(name,pass);
           return user;
       }
       #endregion





   }
}
