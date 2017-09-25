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
    [Authorize]//(Roles = "user")
    public class UserController : Controller
    {
        public readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }









        [Authorize(Roles = "verified,admin,user")]////        ÄÎÁÀÂËÅÍÈÅ ÏÎÄÏÈÙÈÊÀ(ÍÀÑÒĞÎÈÒÜ ÂÕÎÄÍÛÅ ÄÀÍÍÛÅ) 
        [HttpPost, ActionName("AddSubscriber")]
        public async Task<IActionResult> AddSubscriber(int idUser, int idProject)
        {
            User user = await _context.User.FirstAsync(x => x.ID == idUser);
            Project project = await _context.Project.FirstAsync(x => x.ID == idProject);
            _context.Subscriber.Add(new Subscriber() { Project = project, User = user });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "verified,admin,user")]////        ÓÄÀËÅÍÈÅ ÏÎÄÏÈÙÈÊÀ(ÍÀÑÒĞÎÈÒÜ ÂÕÎÄÍÛÅ ÄÀÍÍÛÅ) 
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


        [HttpGet]
        //[Authorize(Roles = "user")]////                                 ÄÎÁÀÂËÅÍÈÅ ÑÊÀÍÀ ÏÀÑÏÎĞÒÀ(íóæíî äîáàâèòü ñîáûòèå)
        public  IActionResult PassportScan()
        {
            return View();
        }
        
        [Authorize  ]////    (Roles = "user")                           ÄÎÁÀÂËÅÍÈÅ ÑÊÀÍÀ ÏÀÑÏÎĞÒÀ(íóæíî äîáàâèòü ñîáûòèå)
        [HttpPost, ActionName("PassportScan")]
        public async Task<IActionResult> PassportScanLoad(UserViewModel pvm)
        {

            User person = await _context.User.FirstAsync(x => x.IdentityUser.UserName == User.Identity.Name);
            if (person.PasportScan!=null )
            {
                ViewBag.eror = "you have already downloaded the scan of your passport";               
                return View();
            }
            if (pvm.PasportScan != null&&person.Status=="newUser")
            {
                person.PasportScan = pvm.PasportScan.GetImg();
                person.CommentForVerified = pvm.Comment;
                person.PersonalInfoForVerified = pvm.PersonalInfo;
                person.Status = "applied";
            }
            _context.User.Update(person);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [Authorize]////    (Roles = "user")                           ÄÎÁÀÂËÅÍÈÅ ÀÂÀÒÀĞÀ(íóæíî äîáàâèòü ñîáûòèå)
        [HttpPost, ActionName("Avatar")]
        public async Task<IActionResult> AvatarLoad(UserViewModel pvm)
        {

            User person = await _context.User.FirstAsync(x => x.IdentityUser.UserName == User.Identity.Name);
            if (pvm.Avatar != null)
            {
                person.Avatar = pvm.Avatar.GetImg();
            }
            _context.User.Update(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }






        public IActionResult Index()
        {
            User person =  _context.User.First(x => x.IdentityUser.UserName == User.Identity.Name);
            return View(person);
        }

        public string LoadImage(byte[] photo)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String(photo);
        }
    }
}