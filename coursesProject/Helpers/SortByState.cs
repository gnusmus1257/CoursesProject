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
        public static List<UserViewModel> UsersSort(this  List<UserViewModel> users, string Sort)
        {
            List<UserViewModel> Users = new List<UserViewModel>();
            if (Sort=="all")
            {
                return users;
            }
            foreach (var item in users)
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
