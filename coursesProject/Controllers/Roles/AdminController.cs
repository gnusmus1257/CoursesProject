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

namespace coursesProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        public readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]////        аюм чгепю (мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("LockUsers")]
        public async Task<IActionResult> LockUsers(int[] idUsers)
        {
            List<User> Users = new List<Models.User>();
            for (int i = 0; i < idUsers.Length; i++)
            {
                Users.Add(UserHelper.GetUserById(idUsers[i], _context));
                Users[i].IsBan = true;
                _context.User.Update(Users[i]);
            }
            await _context.SaveChangesAsync();
            return Redirect("Index");
        }

        [Authorize(Roles = "admin")]////        пюгаюм чгепю (мюярпнхрэ бундмше дюммше) 
        [HttpPost, ActionName("UnlockUsrs")]
        public async Task<IActionResult> UnlockUsers(int[] idUsers)
        {
            List<User> Users = new List<Models.User>();
            for (int i = 0; i < idUsers.Length; i++)
            {
                Users.Add(UserHelper.GetUserById(idUsers[i], _context));
                Users[i].IsBan = false;
                _context.User.Update(Users[i]);
            }
            await _context.SaveChangesAsync();
            return Redirect("Index");
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
            return PartialView("verified".UsersSort(_context));
        }


        [Authorize(Roles = "admin")]////                                онкэгнбюрекх ондюбьхе гюъбйх (бепмер вюярхвмне опедярюбкемхе)
        public IActionResult AppliedUsers()
        {
            return PartialView("Applied".UsersSort(_context));
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}