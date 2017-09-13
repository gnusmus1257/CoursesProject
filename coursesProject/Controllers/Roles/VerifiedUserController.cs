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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(string nameProject, string descrtiption, DateTime endTime, byte[] avatar, string category, int needMoney, string goal)
        {
            Project project = (new Project()
            {
                NameProject = nameProject,
                Status = "newUser",
                Avatar = avatar,
                Category = await _context.Category.FirstAsync(x => x.Name == category),
                Athor = await _context.User.FirstAsync(x => x.IdentityUser == User.Identity),
                DateOfRigister = DateTime.Now,
                EndDate = endTime,
                Description = descrtiption,
                Raiting = 0
            });
            project.Goals.Add(new Goal() { Project = project, NeedMoney = needMoney, Text = goal });
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "verified,admin")]////        днаюбкемхе мнбнярх(мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("AddTopic")]
        public async Task<IActionResult> AddTopic(string Topic, int idProject)
        {
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            New topic = new New() { Project = project, Text = Topic };
            project.News.Add(topic);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "verified,admin")]////        днаюбкемхе мнбни жекх(мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("AddGoal")]
        public async Task<IActionResult> AddGoal(int needMoney, int idProject, string goal)
        {
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            project.Goals.Add(new Goal() { Project = project, NeedMoney = needMoney, Text = goal });
            _context.Project.Update(project);
            await _context.SaveChangesAsync();
            return Ok();
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}