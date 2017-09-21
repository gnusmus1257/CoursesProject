using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coursesProject.Data;
using Microsoft.AspNetCore.Authorization;
using coursesProject.Models;
using Microsoft.EntityFrameworkCore;

namespace coursesProject.Controllers.Roles
{
    [Authorize(Roles = "verified")]
    public class VerifiedUserController : Controller
    {
        
        public readonly ApplicationDbContext _context;

        public VerifiedUserController (ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateProject(string nameProject, string descrtiption, DateTime endTime, byte[] avatar, string category, int needMoney, string goal)
        //{
        //    Project project = new Project();
        //    project.NameProject = nameProject;
        //    project.Status = "newUser";
        //    project.Avatar = avatar;
        //    project.Category = category;
        //    project.Athor = _context.;
        //    project.DateOfRigister = DateTime.Now;
        //    project.EndDate = endTime;
        //    project.Description = descrtiption;
        //    project.Raiting = 0;
        //    project.Goals.Add(new Goal() { Project = project, NeedMoney = needMoney, Text = goal });
        //    _context.Project.Add(project);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "verified,admin")]////        ƒŒ¡¿¬À≈Õ»≈ ÕŒ¬Œ—“»(Õ¿—“–Œ»“‹ ¬’ŒƒÕ€≈ ƒ¿ÕÕ€≈) 
        [HttpPost, ActionName("AddTopic")]
        public async Task<IActionResult> AddTopic(string Topic, int idProject)
        {
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            New topic = new New() { Project = project, Text = Topic };
            project.News.Add(topic);
            await _context.SaveChangesAsync();
            return Ok();
        }






        public IActionResult Index()
        {
            return View();
        }
    }
}