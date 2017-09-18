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
            MinProjectVM.MinDescription = project.ShortDescription;
            MinProjectVM.NameProject = project.NameProject;
            MinProjectVM.Status = project.Status;
            MinProjectVM.Raiting = project.Raiting;
            MinProjectVM.EndDate = project.EndDate;
            MinProjectVM.CollectMoney = project.CollectMoney;
            return MinProjectVM;
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
