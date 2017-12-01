using coursesProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Helpers
{
    public static class GoalsHelper
    {
        public static List<Goal> GetListGoals(this ICollection<Goal> Goals, Project project)
        {
            List<Goal> result = new List<Goal>();
            foreach (var item in Goals)
            {
                if (item.Project == project)
                {
                    result.Add(item);
                }
            }
            return result;
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