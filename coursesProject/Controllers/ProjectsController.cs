using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using coursesProject.Data;
using coursesProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using coursesProject.Service;
using coursesProject.Helpers;
using coursesProject.Models.ProjectViewModels;

namespace coursesProject.Controllers
{
    public class ProjectsController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        
            // GET: Projects
            public async Task<IActionResult> Index()
        {
            List<Project> Projects = await _context.Project.ToListAsync();
            List<MinProjectViewModel> MinModels = new List<MinProjectViewModel>();
            for (int i = 0; i < Projects.Count; i++)
            {
                MinModels.Add(Projects[i].ProjectToMVM());
            }
            return View(MinModels);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var project =_context.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles ="verified,admin,user")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(CreateProjectViewModel CreateModel)
        {
            Project project = new Project();

            project.NameProject = CreateModel.nameProject;
            project.Status = "newUser";
            project.Avatar = CreateModel.GetImg();
            //project.Category = await _context.Category.FirstAsync(x => x.Name == CreateModel.Category);
            project.Athor =_context.GetIdentityUser(User.Identity.Name);
            project.DateOfRigister = DateTime.Now;
            project.EndDate = CreateModel.EndTime;
            project.Description = CreateModel.Descrtiption;
            project.Raiting = 0;
            project.ShortDescription = CreateModel.ShortDescription;
            project.Goals.Add(new Goal() { Project = project, NeedMoney = CreateModel.NeedMoney, Text = CreateModel.Goal });
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.SingleOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="verified,admin")]
        public async Task<IActionResult> Edit(int id, string descrtiption, DateTime endTime, byte[] avatar, int needMoney, string goal)
        {
            Project project =_context.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            project.Description = descrtiption;
            project.EndDate = endTime;
            project.Avatar = avatar;
            project.GetStartGoal().NeedMoney = needMoney;
            project.GetStartGoal().Text = goal;
            _context.Update(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .SingleOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.SingleOrDefaultAsync(m => m.ID == id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ID == id);
        }
    }
}
