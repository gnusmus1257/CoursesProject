using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class UpdateStatus
    {
        public static Project updateStatus(this Project project )
        {
            if (project.GetStartGoal()==null){
                return null;
            }

            if (project.EndDate >= DateTime.Now && project.GetStartGoal().NeedMoney > project.CollectMoney)
            {
                project.Status = "Fail";
            }
            else if (project.EndDate >= DateTime.Now && project.GetStartGoal().NeedMoney <= project.CollectMoney)
            {
                project.Status = "Sucsess";
            }
            else project.Status = "Active";

                return project;
        }

        
    }
}
