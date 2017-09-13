using coursesProject.Data;
using coursesProject.Models;
using System.Linq;

namespace coursesProject.Helpers
{
    public static class UserHelper
    {
        public static User GetUserById(int idUser, ApplicationDbContext _context)
        {
            User user =  _context.User.First(x => x.ID == idUser);
            return user;
        }
    }
}
