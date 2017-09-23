using coursesProject.Data;
using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class TagHelper
    {
        public static List<Tag> GetListTags(this ApplicationDbContext _context, Project project)
        {
            List<Tag> Tags = new List<Tag>();
            foreach (var item in _context.Tag)
            {
                if (item.Project == project)
                {
                    Tags.Add(item);
                }
            }
            return Tags;
        }



        public static void RemoveAllTagsProject(this ApplicationDbContext _context, Project project)
        {
            foreach (var item in _context.GetListTags(project))
            {
                _context.Tag.Remove(item);
            }
            _context.SaveChanges();
        }

        public static void RemoveAllTags (this ApplicationDbContext _context)
        {
            foreach (var item in _context.Tag.ToList())
            {
                _context.Tag.Remove(item);
            }
        }

        public static Tag IsExistTag (this ApplicationDbContext _context, string str)
        {
            var tag= _context.Tag.FirstOrDefault(x => x.Name == str);
            if (tag!=null&&tag.Name==str)
            {
                return tag;
            }
            tag = new Tag() { Name = str };
            _context.Tag.Add(tag);
            _context.SaveChanges();
            return tag;
        }

    }
}
