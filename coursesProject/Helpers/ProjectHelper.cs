using coursesProject.Data;
using coursesProject.Models;
using coursesProject.Models.ProjectViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class ProjectHelper
    {
        public static Project GetProjectById (this ApplicationDbContext _context, int ProjectID)
        {
            Project project = _context.Project.First(x => x.ID == ProjectID);
            return project;
        }

        public static MinProjectViewModel ProjectToMVM(this Project project)
        {
            MinProjectViewModel MinProjectVM = new MinProjectViewModel();
            MinProjectVM.AvatarByte = project.Avatar;
            MinProjectVM.Category = project.Category;
            MinProjectVM.MinDescription = project.ShortDescription.GetShortDescrtiption(130);
            MinProjectVM.NameProject = project.NameProject;
            if (project.Athor!=null)
            {
                MinProjectVM.Author = project.Athor.Email;
            }
            MinProjectVM.Author = project.AthorEmail;
            MinProjectVM.Status = project.Status;
            MinProjectVM.Raiting = project.Raiting;
            MinProjectVM.EndDate = project.EndDate;
            MinProjectVM.CollectMoney = project.CollectMoney;
            MinProjectVM.Goals = project.Goals;
            if (project.GetStartGoal()!=null && project.GetStartGoal().NeedMoney > 0)
            {
                MinProjectVM.NeedMoney = project.GetStartGoal().NeedMoney;
                MinProjectVM.Goal = project.GetStartGoal().Text;
            }
            MinProjectVM.NeedMoney = project.NeedMoney;
            MinProjectVM.Project = project.ID;            
            return MinProjectVM;
        }


        public static string GetShortDescrtiption (this string str, int count)
        {
            if (str.Length<=count) { return str;}
            string temp = "";
            for (int i = 0; i < count-3; i++)
            {
                temp += str[i];
            }
            temp += "...";
            return temp;
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

        //public static Project CVMToProject(this CreateProjectViewModel CreateModel)
        //{
        //    Project CreateProjectVM = new Project() {
        //        NameProject = CreateModel.nameProject,
        //        Status = "newUser",
        //        Avatar = CreateModel.GetImg(),
        //        Category = CreateModel.Category,
        //        Athor = await _context.User.FirstAsync(x => x.IdentityUser == User.Identity),
        //        DateOfRigister = DateTime.Now,
        //        EndDate = CreateModel.EndTime,
        //        Description = CreateModel.Descrtiption,
        //        Raiting = 0,
        //        ShortDescription = CreateModel.ShortDescription
        //    };
        //    CreateProjectVM.AvatarByte = project.Avatar;
        //    CreateProjectVM.Category = project.Category;
        //    CreateProjectVM.MinDescription = project.ShortDescription;
        //    CreateProjectVM.NameProject = project.NameProject;
        //    CreateProjectVM.Status = project.Status;
        //    CreateProjectVM.Raiting = project.Raiting;
        //    CreateProjectVM.EndDate = project.EndDate;
        //    CreateProjectVM.CollectMoney = project.CollectMoney;
        //    return CreateProjectVM;
        //}
    }
}
