using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL
{
    public class ProjectServer
    {
        /*
        public Model.Project_pass getProject_pass(){
        }*/
        #region 获取搜索数据模型1
        public static List<DAL.getDefaultProject_Result> getSearchResult(List<DAL.getDefaultProject_Result> projectInfo, string str2, string str4, string str5)
        {
            if (str4.Equals("p_id"))
            {
                switch (str5)
                {
                    case "asc":
                        projectInfo = (from rerult in projectInfo where (rerult.p_rank.Equals(str2)) orderby rerult.p_id ascending select rerult).ToList();
                        break;
                    case "desc":
                        projectInfo = (from rerult in projectInfo where (rerult.p_rank.Equals(str2)) orderby rerult.p_id descending select rerult).ToList();
                        break;
                    default:
                        projectInfo = (from rerult in projectInfo  orderby rerult.p_id descending select rerult).ToList();
                        break;



                }
            }
            else
            {
                switch (str5)
                {
                    case "asc":
                        projectInfo = (from rerult in projectInfo where (rerult.p_rank.Equals(str2)) orderby rerult.plan_closing_time ascending select rerult).ToList();
                        break;
                    case "desc":
                        projectInfo = (from rerult in projectInfo where (rerult.p_rank.Equals(str2)) orderby rerult.plan_closing_time descending select rerult).ToList();
                        break;
                    default:
                        projectInfo = (from rerult in projectInfo orderby rerult.p_id descending select rerult).ToList();
                        break;


                }
            }
          
            return projectInfo;
        }
        #endregion

        #region 获取搜索json html
        public static string getJsonHtml(List<DAL.getDefaultProject_Result> projectInfo)
        {
            StringBuilder htmlStr=new StringBuilder();
          
            foreach(var project in projectInfo){
              
                htmlStr.Append("<tr>");
                htmlStr.Append("<td>"+project.p_id+"</td>");
                htmlStr.Append("<td>"+project.p_type+"</td>");
                htmlStr.Append("<td>" + project.p_name + "</td>");
                htmlStr.Append("<td>" + project.st_name + "</td>");
                htmlStr.Append("<td>"+project.st_name+"</td>");
                htmlStr.Append("<td>" + project.p_rank + "</td>");
                htmlStr.Append("<td>" + project.plan_closing_time + "</td>");
                htmlStr.Append(" <td><button type=\"button\" class=\"btn btn-embossed btn-primary btn-xs\" data-toggle=\"modal\" data-target=\"#myModal_ShowDetail\">详情</button></td>");
                htmlStr.Append("</tr>");
            }
           
            
           // htmlStr.Append("<tr><td>1</td><td>思科</td><td>IT</td><td>某某某项目</td><td>张朝钿</td><td>审核一</td><td>国家级</td><td>2015-10-29</td></tr>");
            return htmlStr.ToString();
        }
        #endregion

        #region 获取搜索数据模型2
        public static List<DAL.getDefaultProject_Result> getSearchResult2(List<DAL.getDefaultProject_Result> projectInfo, string keyword_type, string keyword)
        {
            switch (keyword_type)
            {
                case "p_type":
                 projectInfo=(from result in projectInfo where result.p_type.Contains(keyword) select result).ToList();
                 break;
                case "p_name":
                 projectInfo=(from result in projectInfo where result.p_name.Contains(keyword) select result).ToList();
                 break;
                case "st_name":
                   projectInfo=(from result in projectInfo where result.st_name.Contains(keyword) select result).ToList();
                 break;
            }
            return projectInfo;
        }
        #endregion

        #region 获取项目进度模型
        public static List<Model.Project_Schedule_Model> getScheduleModel()
        {
            DAL.ProjectInfoDAL proejct = new DAL.ProjectInfoDAL();
            return proejct.GetScheduleModel();
        }


        #endregion

    }
}