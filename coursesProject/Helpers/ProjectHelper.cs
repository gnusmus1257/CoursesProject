using coursesProject.Data;
using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class ProjectHelper
    {
        public static Project GetProjectById (int ProjectID, ApplicationDbContext _context)
        {
            Project project = _context.Project.First(x => x.ID == ProjectID);
            return project;
        }
    }
}
