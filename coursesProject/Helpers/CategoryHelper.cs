using coursesProject.Data;
using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class CategoryHelper
    {
        public static void CreateCategoryIfNotExist(this ApplicationDbContext _context, string str)
        {
            var tag = _context.Category.FirstOrDefault(x => x.Name == str);
            if (tag == null || tag.Name != str)
            {
                _context.Category.Add(new Category() { Name = str });
            }
        }
    }
}
