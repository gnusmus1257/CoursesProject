using coursesProject.Data;
using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class TopicHelper
    {
        public static List<New> GetListTopics(this ApplicationDbContext _context, Project project)
        {
            List<New> Topics = new List<New>();
            foreach (var item in _context.Topic)
            {
                if (item.Project == project)
                {
                    Topics.Add(item);
                }
            }
            return Topics;
        }
    }
}
