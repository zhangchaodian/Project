using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProjectManager.Model;


namespace ProjectManager.DAL
{
   public class ProjectInfoDAL
    {
       public static List<getDefaultProject_Result> getProject_pass_Info()
       {
           DAL.ProjectManagerDBEntities2 context = new DAL.ProjectManagerDBEntities2();
           return context.getDefaultProject().ToList();
       }

       #region 获取项目进度
       public static string getSchedule(string p_id)
       {
           string sql = "select * from StageTask where p_id=@p_id";
           SqlParameter[] pars = { 
                                 new SqlParameter("@p_id",SqlDbType.NVarChar,32),
                                  
                                 };
           pars[0].Value = p_id;
           DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
           double total_num = da.Rows.Count;
           string sql2 = "select * from StageTask where p_id=@p_id and f_state=1";
           SqlParameter[] pars2= { 
                                 new SqlParameter("@p_id",SqlDbType.NVarChar,32),
                                  
                                 };
           pars2[0].Value = p_id;
           DataTable da2 = SqlHelper.GetTable(sql2, CommandType.Text, pars2);
           double f_num = da2.Rows.Count;
           double schedule = f_num / total_num;
           return schedule*100+ "%";

        
       }

       public List< Model.Project_Schedule_Model> GetScheduleModel()
       {
           List<Project_Schedule_Model> schedule_model = new List<Project_Schedule_Model>();
           string sql="select p_id,p_name,p_type,st_name,p_rank,st_name,p_rank,apprval_time from project,p_mainType,p_subType,projectRank where project.st_id=p_subType.st_id and p_subType.t_id=p_mainType.t_id and project.rank_id=projectRank.rack_id";

           DataTable da = SqlHelper.GetTable(sql,CommandType.Text,null);
           foreach (DataRow row in da.Rows)
           {
               Project_Schedule_Model project = new Project_Schedule_Model();
               project.p_id = row["p_id"].ToString();
               project.p_name = row["p_name"].ToString();
               project.p_type = row["p_type"].ToString();
               project.st_name = row["st_name"].ToString();
               project.p_rank = row["p_rank"].ToString();
               project.apprval_time = Convert.ToDateTime(row["apprval_time"]);
               project.p_schedule = getSchedule(project.p_id);
               schedule_model.Add(project);
               

           }
           return schedule_model;

       }

       #endregion
    }
}
