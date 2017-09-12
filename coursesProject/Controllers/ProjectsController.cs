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

namespace coursesProject.Controllers
{
    public class ProjectsController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("DeleteUser")]
        public async Task<ActionResult> DeleteUsersAndProjectConfirmed(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            User userModel = await _context.User.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            _context.User.Remove(userModel);           
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "admin")]////                                опнбепеммше онкэгнбюрекх  (бепмер вюярхвмне опедярюбкемхе)
        public IActionResult verifiedUsers()
        {           
            return PartialView( "verified".UsersSort(_context));
        }


        [Authorize(Roles = "admin")]////                                онкэгнбюрекх ондюбьхе гюъбйх (бепмер вюярхвмне опедярюбкемхе)
        public IActionResult AppliedUsers()
        {
            return PartialView("Applied".UsersSort(_context));
        }


        [Authorize(Roles = "user")]////                                 днаюбкемхе яйюмю оюяонпрю(МСФМН ДНАЮБХРЭ ЯНАШРХЕ)
        [HttpPost, ActionName("PassportScan")]
        public async Task<IActionResult> PassportScan(UserViewModel pvm)
        {
            User person =await _context.User.FirstAsync(x => x.ID == pvm.ID);
            if (pvm.Avatar != null)
            {
                person.PasportScan = pvm.GetImg();
            }
            _context.User.Update(person);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "verified,admin,user")]////        днаюбкемхе йнлемрю(мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("AddComment")]
        public async Task<IActionResult> AddComment(int idUser, int idProject, string text)
        {
            User user = await _context.User.FirstAsync(x => x.ID == idUser);
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            Comment comm = new Comment() { Project = project, Author = user, Context = text, DateCreate = DateTime.Now };
            project.Comment.Add(comm);
            _context.SaveChanges();
            return Ok();
        }


        [Authorize(Roles = "verified,admin,user")]////        днаюбкемхе мнбнярх(мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("AddTopic")]
        public async Task<IActionResult> AddTopic(string Topic, int idProject)
        {
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            New topic = new New() { Project = project, Text = Topic };
            project.News.Add(topic);
            await _context.SaveChangesAsync();
            return Ok();
        }



        [Authorize(Roles = "verified,admin,user")]////        днаюбкемхе ондохыхйю(мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("AddSubscriber")]
        public async Task<IActionResult> AddSubscriber(int idUser, int idProject)
        {
            User user = await _context.User.FirstAsync(x => x.ID == idUser);
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            _context.Subscriber.Add(new Subscriber() { Project = project, User = user });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "verified,admin,user")]////        сдюкемхе ондохыхйю(мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("RemoveSubscriber")]
        public async Task<IActionResult> RemoveSubscriber(int idUser, int idProject)
        {
            User user = await _context.User.FirstAsync(x => x.ID == idUser);
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            Subscriber sub = await _context.Subscriber.FirstAsync(x => x.User == user && x.Project == project);
            _context.Subscriber.Remove(sub);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "verified,admin,user")]////        днаюбкемхе пеирхмцю(мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("AddRating")]
        public async Task<IActionResult> AddRating(int idUser, int idProject, int Rating)
        {
            User user = await _context.User.FirstAsync(x => x.ID == idUser);
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            Rating rating = new Rating() { Project = project, User = user,  rating=Rating};
            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();
            return Ok();
        }

        

            // GET: Projects
            public async Task<IActionResult> Index()
        {
            return View(await _context.Project.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    DateOfRigister = DateTime.Now, EndDate = endTime,
                    Description = descrtiption,
                    Raiting = 0
                });
                project.Goals.Add(new Goal() { Project = project, NeedMoney = needMoney, Text = goal });
                _context.Project.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");        
        }

        
        [Authorize(Roles = "verified,admin,user")]////        днаюбкемхе мнбни жекх(мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("AddGoal")]
        public async Task<IActionResult> AddGoal(int needMoney, int idProject, string goal)
        {
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            project.Goals.Add(new Goal() { Project = project, NeedMoney = needMoney, Text = goal });
            _context.Project.Update(project);
            await _context.SaveChangesAsync();
            return Ok();
        }

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
        public async Task<IActionResult> Edit(int id, [Bind("ID,NameProject,Date,Status,Description,Raiting")] Project project)
        {
            if (id != project.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(project);
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
