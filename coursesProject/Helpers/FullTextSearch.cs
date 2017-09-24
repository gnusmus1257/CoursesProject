using coursesProject.Data;
using coursesProject.Models;
using coursesProject.Models.ProjectViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class FullTextSearch
    {
        public static List<MinProjectViewModel> Search (this List<Project> projects, string Search,string Email)
        { 
            List<MinProjectViewModel> MinModels = new List<MinProjectViewModel>();
            if (Search==""|| Search == null)
            {
                foreach (var item in projects)
                {
                    MinModels.Add(item.ProjectToMVM(Email));
                }
                return MinModels;
            }
            foreach (var item in projects)
            {
                if (item.Category==Search)
                {
                    MinModels.Add(item.ProjectToMVM(Email));
                }
                else
                if (item.IsExistTag(Search))
                {
                    MinModels.Add(item.ProjectToMVM(Email));
                }else
                if (item.NameProject==Search)
                {
                    MinModels.Add(item.ProjectToMVM(Email));
                }
                else
                if (item.IsExistGoal(Search))
                {
                    MinModels.Add(item.ProjectToMVM(Email));
                }else
                if (item.IsExistComment(Search))
                {
                    MinModels.Add(item.ProjectToMVM(Email));
                }
            }
            if (MinModels.Count!=0)
            {
                return MinModels;
            }
            else foreach(var item in projects)
                {
                MinModels.Add(item.ProjectToMVM(Email));
            }
            return MinModels;
        }
    }
}
