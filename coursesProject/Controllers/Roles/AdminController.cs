using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using coursesProject.Models;
using coursesProject.Data;
using coursesProject.Helpers;
using coursesProject.Service;
using Microsoft.AspNetCore.Identity;

namespace coursesProject.Controllers
{
    [Authorize(Roles = "admin")]//
    public class AdminController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize]////   (Roles = "admin")     ��� ����� (��������� ������� ������) 
        //[HttpPost, ActionName("LockUsers")]
        public async Task<IActionResult> LockUsers(List<int> idUsers)
        {
            List<User> Users = new List<User>();
            for (int i = 0; i < idUsers.Count; i++)
            {
                Users.Add(_context.GetUserById(idUsers[i]));
                var IdentityUser= _context.Users.First(x => x.Email == Users[i].Email);
                Users[i].IsBan = true;
                IdentityUser.LockoutEnabled = true;
                IdentityUser.LockoutEnd = DateTime.UtcNow.AddMinutes(42);
                await _userManager.UpdateAsync(IdentityUser);
                _context.Update(IdentityUser);
                _context.Update(Users[i]);
                _context.User.Update(Users[i]);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }




        [Authorize]////   (Roles = "admin")     ������ ����� (��������� ������� ������) 
        //[HttpPost, ActionName("UnlockUsrs")]
        public async Task<IActionResult> UnlockUsers(List<int> idUsers)
        {
            List<User> Users = new List<Models.User>();
            for (int i = 0; i < idUsers.Count; i++)
            {
                Users.Add(_context.GetUserById(idUsers[i]));
                var IdentityUser = _context.Users.First(x => x.Email == Users[i].Email);
                IdentityUser.LockoutEnabled = false;
                Users[i].IsBan = false;
                await _userManager.UpdateAsync(IdentityUser);
                _context.Update(IdentityUser);
                _context.User.Update(Users[i]);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize]//(Roles = "admin")                  �������� ������������ 
        //[HttpPost, ActionName("DeleteUser")]
        public async Task<ActionResult> DeleteUsersAndProjectConfirmed(List<int> idUsers)
        {
            List<User> users = _context.GetUserListByListID(idUsers);
            foreach (var item in users)
            {
                _context.Users.Remove(_context.Users.First(x=>x.UserName==item.Email));
                _context.User.Remove(item);
            }   
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        //[Authorize]////      (Roles = "admin")                          ����������� ������������  (������ ��������� �������������)
        //public IActionResult verifiedUsers()
        //{
        //    return PartialView("verified".UsersSort(_context));
        //}


        //[Authorize]////       (Roles = "admin")                         ������������ �������� ������ (������ ��������� �������������)
        //public IActionResult AppliedUsers()
        //{
        //    return PartialView("Applied".UsersSort(_context));
        //}



        [HttpGet, ActionName("Verified")]
        public ActionResult Verified (int id)
        {
            User user = _context.GetUserById(id);
            UserViewModel uvm = user.UserToVM();
            return View(uvm);
        }


        
        public async Task<ActionResult> VerifiedConfirmed(int id)
        {
            User user = _context.User.First(x => x.ID == id);
            if (user.Status != "applied") return RedirectToAction("Index"); 
            user.PasportScan = null;
            user.Status = "verified";
            _context.Update(user);
            var User = _context.Users.First(x => x.Email == user.Email);
            await _userManager.AddToRoleAsync(User, "verified");
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        
        public async Task<ActionResult> VerifiedUnConfirmed(int id)
        {
            User user = _context.User.First(x=>x.ID==id);
            if (user.Status != "applied") return RedirectToAction("Index");
            user.PasportScan = null;
            user.Status = "newUser";
            _context.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index(string param = "all")
        {
            return View(_context.GetListUVM().UsersSort(param));
        }


        public IActionResult IndexSorted(string param)
        {           
            return View("Index",_context.GetListUVM().UsersSort(param));
        }
        
    }
}