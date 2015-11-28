using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProjectManager.DAL
{
  public  class UserInfoDAL
    {
      public userinfo GetUserInfo(string name,string pass)
      {
          string sql = "select* from userinfo where name=@username and userPwd=@pwd";
          SqlParameter[] pars ={ 
                                 new SqlParameter("@username",SqlDbType.NVarChar,32),
                                 new SqlParameter("@pwd",SqlDbType.NVarChar,32),
                                 };
          pars[0].Value = name;
          pars[1].Value = pass;
          DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
          userinfo userInfo = null;
          if (da.Rows.Count > 0)
          {
              userInfo = new userinfo();
              LoadEntity(userInfo, da.Rows[0]);
          }
          return userInfo;

      }
      public void LoadEntity(userinfo userInfo, DataRow row)
      {
          userInfo.ID = row["ID"].ToString();
          userInfo.mainbox = row["mainbox"].ToString();
          userInfo.name = row["name"].ToString();
          userInfo.phoneNumber = row["phoneNumber"].ToString();
          userInfo.sex = row["sex"].ToString();
          userInfo.userType=row["userType"].ToString();
          

      }
    }
}
