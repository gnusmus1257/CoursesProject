using coursesProject.Data;
using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class RatingHelper
    {
        public static double GetRating(this ApplicationDbContext context, Project project)
        {
            double rating = 0;
            int count = 0;
            foreach (var item in context.Rating)
            {
                if (project==item.Project)
                {
                    count++;
                    rating += item.rating;
                }
            }
            return rating/count;
        }
    }
}
