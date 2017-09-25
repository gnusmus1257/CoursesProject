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


        public IActionResult Index()
        {
            return View();
        }
    }
}