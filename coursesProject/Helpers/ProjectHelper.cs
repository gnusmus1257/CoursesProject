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

        public static MinProjectViewModel ProjectToMVM(this Project project, string IdentityUser)
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
            MinProjectVM.IdentityUser = IdentityUser;
            if (project.GetStartGoal()!=null && project.GetStartGoal().NeedMoney > 0)
            {
                MinProjectVM.NeedMoney = project.GetStartGoal().NeedMoney;
                MinProjectVM.Goal = project.GetStartGoal().Text;
            }
            MinProjectVM.NeedMoney = project.NeedMoney;
            MinProjectVM.Project = project.ID;            
            return MinProjectVM;
        }


        public static DetailProjectViewModel ProjectToDVM(this Project project, string IdentityUser)
        {
            DetailProjectViewModel DetailProjectVM = new DetailProjectViewModel();
            DetailProjectVM.Avatar = project.Avatar;
            DetailProjectVM.Category = project.Category;
            DetailProjectVM.Description = project.Description;
            DetailProjectVM.ShortDescription = project.ShortDescription.GetShortDescrtiption(130);
            DetailProjectVM.NameProject = project.NameProject;
            if (project.Athor != null)
            {
                DetailProjectVM.Athor = project.Athor;
            }
            DetailProjectVM.AthorEmail = project.AthorEmail;
            DetailProjectVM.DateOfRigister = project.DateOfRigister;
            DetailProjectVM.Status = project.Status;
            DetailProjectVM.Raiting = project.Raiting;
            DetailProjectVM.EndDate = project.EndDate;
            DetailProjectVM.CollectMoney = project.CollectMoney;
            DetailProjectVM.Goals = project.Goals;
            DetailProjectVM.Comments = project.Comment;
            DetailProjectVM.News = project.News;
            DetailProjectVM.TagStr = project.Tags.TagsListToStr();
            if (DetailProjectVM.AthorEmail==IdentityUser)
            {
                DetailProjectVM.IsAthor = true;
            }
            else DetailProjectVM.IsAthor = false;
            DetailProjectVM.NeedMoney = project.NeedMoney;
            DetailProjectVM.ID = project.ID;
            return DetailProjectVM;
        }

        public static EditProjectViewModel ProjectToEVM(this Project project)
        {
            EditProjectViewModel EditProjectVM = new EditProjectViewModel();
            EditProjectVM.ShortDescription = project.ShortDescription.GetShortDescrtiption(130);
            EditProjectVM.NameProject = project.NameProject;
            EditProjectVM.EndDate = project.EndDate;
            EditProjectVM.NeedMoney = project.NeedMoney;
            EditProjectVM.ID = project.ID;
            return EditProjectVM;
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

        public static DetailProjectViewModel UpdateListsDVM (this ApplicationDbContext _context, int ID, string Email)
        {
            var project =  _context.Project.First(x => x.ID == ID);
            project.Goals = _context.GetListGoals(project);
            project.Comment = _context.GetListComments(project);
            project.Tags = _context.GetListTags(project);
            project.News = _context.GetListTopics(project);
            project.Raiting = _context.GetRating(project);
            var ViewModel = project.ProjectToDVM(Email);
            return ViewModel;
        }

        public static MinProjectViewModel UpdateListsMVM(this Project project, ApplicationDbContext _context, string Email)
        {
            project.Goals = _context.GetListGoals(project);
            project.Comment = _context.GetListComments(project);
            project.Tags = _context.GetListTags(project);
            var ViewModel = project.ProjectToMVM(Email);
            return ViewModel;
        }

        public static string TagsListToStr(this ICollection<Tag> tags)
        {
            string str = "";
            foreach (var item in tags)
            {
                str += item.Name + " ";
            }
            return str;
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
