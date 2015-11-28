using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Model;

namespace ProjectManager.DAL
{
    public class Login
    {
        public List<Check_Login_Result> Check(string username,string password)
        {
            DAL.ProjectManagerDBEntities context = new DAL.ProjectManagerDBEntities();
            return context.Check_Login(username,password).ToList();
        }
    }
}
