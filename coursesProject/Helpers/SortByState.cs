using coursesProject.Data;
using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class SortByState
    {
        public static List<User> UsersSort(this string Sort, ApplicationDbContext context)
        {
            List<User> Users = new List<Models.User>();
            foreach (var item in context.User)
            {
                if (item.Status == Sort)//                      ЕСЛИ ПРОВЕРЕННЫЙ = verified   ЕСЛИ ПОДАЛИ ЗАЯВКУ = Applied
                {
                    Users.Add(item);
                }
            }
            return Users;
        }
    }
}
