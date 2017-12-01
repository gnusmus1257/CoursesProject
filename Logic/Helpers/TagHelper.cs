using coursesProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Helpers
{
    public static class TagHelper
    {
        public static List<Tag> GetListTags(this ICollection<Tag> Tags, Project project)
        {
            List<Tag> result = new List<Tag>();
            foreach (var item in Tags)
            {
                if (item.Project == project)
                {
                    Tags.Add(item);
                }
            }
            return result;
        }

        public static bool IsExistTag(this Project project, string str)
        {
            var tag = project.Tags.FirstOrDefault(x => x.Name == str);
            if (tag != null && tag.Name == str)
            {
                return true;
            }
            return false;
        }

    }
}