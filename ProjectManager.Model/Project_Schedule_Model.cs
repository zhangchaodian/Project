using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Model
{
   public class Project_Schedule_Model
    {
       public string p_id { get; set; }
       public string p_name { get; set; }
       public string p_type { get; set; }
       public string  p_schedule { get; set; }
       public string st_name { get; set; }
       public string p_rank { get; set; }
       public DateTime apprval_time { get; set; }
    }
}
