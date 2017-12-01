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
        //public static double GetRating(this ApplicationDbContext context, Project project)
        //{
        //    double rating = 0;
        //    int count = 0;
        //    foreach (var item in context.Rating)
        //    {
        //        if (project==item.Project)
        //        {
        //            count++;
        //            rating += item.rating;
        //        }
        //    }
        //    if (count!=0)
        //    {
        //        project.Raiting = rating / count;
        //        context.Update(project);
        //        context.SaveChanges();
        //        return rating / count;
        //    }
        //    return 0;
        //}

        //public static void AddRatingIfNotExist(this ApplicationDbContext _context, User user, Project project, int value)
        //{
        //    if (_context.Rating.Count()!=0)
        //    {
        //        var Rating = _context.Rating.FirstOrDefault(x => x.Project == project && x.User == user);
        //        if (Rating != null&&Rating.Project==project&&Rating.User==user)
        //        {
        //            return;
        //        }
        //    }
        //    var rating = new Rating() { Project = project, User = user, rating = value };
        //    _context.Rating.Add(rating);
        //    _context.SaveChanges();
        //}
    }
}
