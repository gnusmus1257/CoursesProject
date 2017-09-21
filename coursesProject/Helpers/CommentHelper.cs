using coursesProject.Data;
using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class CommentHelper
    {
        public static List<Comment> GetListComments(this ApplicationDbContext _context, Project project)
        {
            List<Comment> Comments = new List<Comment>();
            foreach (var item in _context.Comment)
            {
                if (item.Project == project)
                {
                    Comments.Add(item);
                }
            }
            return Comments;
        }
    }
}
