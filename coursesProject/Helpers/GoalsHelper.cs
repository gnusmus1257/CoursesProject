using coursesProject.Data;
using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class GoalsHelper
    {
        public static List<Goal> GetListGoals (this ApplicationDbContext _context, Project project)
        {
            List<Goal> Goals = new List<Goal>();
            foreach (var item in _context.Goal)
            {
                if (item.Project==project)
                {
                    Goals.Add(item);
                }
            }
            return Goals;
        }

        public static Goal GetStartGoal(this Project project)
        {
            List<Goal> Goals = new List<Goal>(project.Goals);
            int minValue = int.MaxValue;
            Goal goal = null;
            for (int i = 0; i < Goals.Count; i++)
            {
                if (Goals[i].NeedMoney < minValue)
                {
                    minValue = Goals[i].NeedMoney;
                    goal = Goals[i];
                }
            }
            return goal;
        }

        public static bool IsExistGoal(this Project project, string str)
        {
            var goal = project.Goals.FirstOrDefault(x => x.Text == str);
            if (goal != null && goal.Text == str)
            {
                return true;
            }
            return false;
        }
    }
}
