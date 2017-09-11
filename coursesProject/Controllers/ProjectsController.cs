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

        private byte[] _GetImg (UserViewModel uvm)
        {
            byte[] imageData = null;
            // ñ÷èòûâàåì ïåğåäàííûé ôàéë â ìàññèâ áàéòîâ
            using (var binaryReader = new BinaryReader(uvm.Avatar.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)uvm.Avatar.Length);
            }
            return imageData;
        }

       
        private List<User> _UsersSort (string Sort)
        {
            List<User> Users = new List<Models.User>();
            foreach (var item in _context.User)
            {
                if (item.Status == Sort)//                      ÅÑËÈ ÏĞÎÂÅĞÅÍÍÛÉ = verified   ÅÑËÈ ÏÎÄÀËÈ ÇÀßÂÊÓ = Applied
                {
                    Users.Add(item);
                }
            }
            return Users;
        }


        [Authorize(Roles = "admin")]////                                ÏĞÎÂÅĞÅÍÍÛÅ ÏÎËÜÇÎÂÀÒÅËÈ  (ÂÅĞÍÅÒ ×ÀÑÒÈ×ÍÎÅ ÏĞÅÄÑÒÀÂËÅÍÈÅ)
        public async Task<IActionResult> verifiedUsers()
        {           
            return PartialView(_UsersSort("verified"));
        }


        [Authorize(Roles = "admin")]////                                ÏÎËÜÇÎÂÀÒÅËÈ ÏÎÄÀÂØÈÅ ÇÀßÂÊÈ (ÂÅĞÍÅÒ ×ÀÑÒÈ×ÍÎÅ ÏĞÅÄÑÒÀÂËÅÍÈÅ)
        public async Task<IActionResult> AppliedUsers()
        {
            return PartialView(_UsersSort("Applied"));
        }


        [Authorize(Roles = "user")]////                                 ÄÎÁÀÂËÅÍÈÅ ÑÊÀÍÀ ÏÀÑÏÎĞÒÀ(íóæíî äîáàâèòü ñîáûòèå)
        [HttpPost, ActionName("PassportScan")]
        public async Task<IActionResult> PassportScan(UserViewModel pvm)
        {
            User person =await _context.User.FirstAsync(x => x.ID == pvm.ID);
            if (pvm.Avatar != null)
            {
                person.PasportScan = _GetImg(pvm);
            }
            _context.User.Update(person);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "verified,admin,user")]////                                 ÄÎÁÀÂËÅÍÈÅ ÊÎÌÅÍÒÀ(ÍÀÑÒĞÎÈÒÜ ÂÕÎÄÍÛÅ ÄÀÍÍÛÅ) 
        [HttpPost, ActionName("AddCommebt")]
        public async Task<IActionResult> AddComment(int idUser, int idProject, string text)
        {
            User user = await _context.User.FirstAsync(x => x.ID == idUser);
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            Comment comm = new Comment() { Project = project, Author = user, Context = text, DateCreate = DateTime.Now };
            project.Comment.Add(comm);
            _context.SaveChanges();
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
        public async Task<IActionResult> Create([Bind("ID,NameProject,Date,Status,Description,Raiting")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(project);
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
