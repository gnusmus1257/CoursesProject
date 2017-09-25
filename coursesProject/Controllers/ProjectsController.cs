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
            for (int i = 0; i < Projects.Count; i++)  { MinModels.Add(Projects[i].ProjectToMVM(User.Identity.Name)); }
            if (MinModels.Count!=0)   { MinModels[0].Categorys = _context.Category.ToList(); }
            return View(MinModels);
        }

        // GET: Projects/Details/5
        public IActionResult Details(int id)
        {
            var project =_context.GetProjectById(id);
            if (project == null) { return NotFound(); }
             _context.updateStatus(project); 
            return View(_context.UpdateListsDVM(id,User.Identity.Name));
        }


        [Authorize(Roles = "verified,admin")]
        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [Authorize(Roles ="verified,admin")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProject(CreateProjectViewModel CreateModel)
        {
            Project project = new Project();
            User user = _context.GetIdentityUser(User.Identity.Name);
            if (CreateModel.Avatar == null)
            {
                ViewBag.imgEror = "select file";
                return View("Create");
            }
            _context.CreateProject(user, CreateModel, project, User.Identity.Name);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        [Authorize(Roles = "verified,admin") ]
        [HttpPost, ActionName("AddGoal")]
        public async Task<IActionResult> AddGoal(int NeedMoney, int ID, string Goal)
        {
            Project project = await _context.Project.FirstAsync(x => x.ID == ID);
            DetailProjectViewModel ViewModel = project.ProjectToDVM(User.Identity.Name);
            if (ViewModel.IsAthor != true)
            {
                ViewBag.GoalEror = "eror";
                return RedirectToAction("Details");
            }
            project.Goals.Add(new Goal() { Project = project, NeedMoney = NeedMoney, Text = Goal });
            _context.Project.Update(project);
            await _context.SaveChangesAsync();
            return View("DetailsUpdate", _context.UpdateListsDVM(ID, User.Identity.Name));
        }

        public ActionResult Search (string Search) 
        {
            var projects = _context.Project.ToList();
            foreach (var item in projects) { item.UpdateListsMVM(_context, User.Identity.Name); }
            List<MinProjectViewModel> MinModels = projects.Search(Search, User.Identity.Name);
            if (projects == null)
            {
                ViewBag.search = "not found";
                foreach (var item in _context.Project.ToList())
                {
                    MinModels.Add(item.ProjectToMVM(User.Identity.Name));
                }
            }
           return View(MinModels);
        }

        [Authorize(Roles = "verified,admin,user")]
        [HttpPost, ActionName("AddComment")]
        public async Task<IActionResult> AddComment(int ID, string Comment)
        {
            User user = _context.GetUserByEmail(User.Identity.Name);
            Project project = await _context.Project.FirstAsync(x => x.ID == ID);
            DetailProjectViewModel ViewModel = project.ProjectToDVM(User.Identity.Name);
            project.Comment.Add(new Comment()
            {
                Project = project,
                Author = user,
                Context = Comment,
                DateCreate = DateTime.Now,
                AuthorEmail = User.Identity.Name
            });
            _context.SaveChanges();
            return View("DetailsUpdate", _context.UpdateListsDVM(ID, User.Identity.Name));
        }




        [Authorize(Roles = "verified,admin")]
        [HttpPost, ActionName("AddTopic")]
        public async Task<IActionResult> AddTopic(string Topic, int ID)
        {
            Project project = await _context.Project.FirstAsync(x => x.ID == ID);
            project.News.Add(new New() { Project = project, Text = Topic });
            _context.Update(project);
            await _context.SaveChangesAsync();
            return View("DetailsUpdate", _context.UpdateListsDVM(ID, User.Identity.Name));
        }


        [Authorize(Roles = "verified,admin,user")]////        ƒŒ¡¿¬À≈Õ»≈ –≈…“»Õ√¿
        [HttpPost, ActionName("AddRating")]
        public async Task<IActionResult> AddRating( int ID, int rating)
        {
            if (rating>=0&&rating<=5) { ViewBag.rating = "eror rating"; }
            else
            {
                User user = await _context.User.FirstAsync(x => x.Email == User.Identity.Name);
                Project project = await _context.Project.FirstAsync(x => x.ID == ID);
                _context.AddRatingIfNotExist(user, project, rating);
            }
            return View("DetailsUpdate", _context.UpdateListsDVM(ID, User.Identity.Name));
        }


        [Authorize(Roles = "verified,admin") ]////       ƒŒ¡¿¬À≈Õ»≈ “≈√¿
        [HttpPost, ActionName("AddTag")]
        public async Task<IActionResult> AddTag(int ID, string Tag)
        {
            User user = _context.GetUserByEmail(User.Identity.Name);
            Project project = await _context.Project.FirstAsync(x => x.ID == ID);
            DetailProjectViewModel ViewModel = project.ProjectToDVM(User.Identity.Name);
            project.Tags.Add( new Tag() { Name=Tag,Project=project});
            _context.Project.Update(project);
            _context.SaveChanges();    
            return View("DetailsUpdate", _context.UpdateListsDVM(ID, User.Identity.Name));
        }

        // GET: Projects/Edit/5
        [Authorize(Roles ="verified,admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            var project = await _context.Project.SingleOrDefaultAsync(m => m.ID == id);
            if (project == null) { return NotFound(); }
            return View(project.ProjectToEVM());
        }



        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="verified,admin")]//
        public IActionResult Edit(EditProjectViewModel Project)
        {
            Project project =_context.GetProjectById(Project.ID);
            if (project == null) return NotFound();
            if (Project.Avatar == null)
            {
                ViewBag.imgEror = "select file";
                return View();
            }
            _context.EditProject(project, Project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Projects/Delete/5
        [Authorize(Roles ="verified,admin")]//
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            var project = await _context.Project.SingleOrDefaultAsync(m => m.ID == id);
            if (project == null) { return NotFound(); }
            return View(project);
        }

        [Authorize(Roles ="verified,admin")]//
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
