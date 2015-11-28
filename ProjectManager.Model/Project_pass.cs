using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Model
{
    //已通过审核的项目数据模型
   public class Project_pass
    {
       public string ID { get; set; }
       public string project_group { get; set; }
       public string p_type { get; set; }
       public string p_name { get; set; }
       public string st_name { get; set; }
       public string remark { get; set; }
       public string rank { get; set; }
       public string plan_closing_date { get; set; }
       public string apprval_time { get; set; }
    }
}
