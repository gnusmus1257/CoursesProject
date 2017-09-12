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
            if (GetStartGoal(project)==null){
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

        public static Goal GetStartGoal(this Project project)
        {
            List<Goal> Goals = new List<Goal>( project.Goals);
            int minValue = int.MaxValue;
            Goal goal = null;
            for (int i = 0; i < Goals.Count; i++)
            {
                if (Goals[i].NeedMoney<minValue)
                {
                    minValue = Goals[i].NeedMoney;
                    goal = Goals[i];
                }
            }
            return goal;
        }
    }
}
