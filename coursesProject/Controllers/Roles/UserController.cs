using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coursesProject.Data;
using Microsoft.AspNetCore.Authorization;
using coursesProject.Models;
using Microsoft.EntityFrameworkCore;
using coursesProject.Service;

namespace coursesProject.Controllers.Roles
{
    [Authorize(Roles = "user")]
    public class UserController : Controller
    {
        public readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
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




        [Authorize(Roles = "user")]////                                 днаюбкемхе яйюмю оюяонпрю(МСФМН ДНАЮБХРЭ ЯНАШРХЕ)
        [HttpPost, ActionName("PassportScan")]
        public async Task<IActionResult> PassportScan(UserViewModel pvm)
        {
            User person = await _context.User.FirstAsync(x => x.ID == pvm.ID);
            if (pvm.Avatar != null)
            {
                person.PasportScan = pvm.GetImg();
            }
            _context.User.Update(person);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "verified,admin,user")]////        днаюбкемхе пеирхмцю(мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("AddRating")]
        public async Task<IActionResult> AddRating(int idUser, int idProject, int Rating)
        {
            User user = await _context.User.FirstAsync(x => x.ID == idUser);
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            Rating rating = new Rating() { Project = project, User = user, rating = Rating };
            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();
            return Ok();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}