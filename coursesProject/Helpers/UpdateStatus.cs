using coursesProject.Data;
using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class UpdateStatus
    {
        public static void updateStatus(this ApplicationDbContext context, Project project )
        {
            if (project.EndDate <= DateTime.Now && project.NeedMoney > project.CollectMoney)
            {
                project.Status = "Fail";
            }
            else if (project.EndDate <= DateTime.Now && project.NeedMoney <= project.CollectMoney)
            {
                project.Status = "Sucsess";
            }
            else project.Status = "Active";
            context.Update(project);
            context.SaveChanges();
        }        
    }
}
