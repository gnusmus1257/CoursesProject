using coursesProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Helpers
{
    public static class UserHelper
    {
        public static User GetUserById(this ICollection<User> _context, int idUser)
        {
            User user = _context.FirstOrDefault(x => x.ID == idUser);
            return user;
        }

        public static User GetUserByEmail(this ICollection<User> _context, string Email)
        {
            User user = _context.FirstOrDefault(x => x.Email == Email);
            return user;
        }

        public static List<User> GetUserListByListID(this ICollection<User> _context, List<int> idUsers)
        {
            List<User> users = new List<User>();
            foreach (var item in idUsers)
            {
                users.Add(_context.First(x => x.ID == item));
            }
            return users;
        }

        public static UserViewModel UserToVM(this User User)
        {
            UserViewModel uvm = new UserViewModel();
            uvm.AvatarByte = User.Avatar;
            uvm.Comment = User.CommentForVerified;
            uvm.Email = User.Email;
            uvm.User = User.ID;
            uvm.IsBanned = User.IsBan;
            uvm.PasportScanByte = User.PasportScan;
            uvm.PersonalInfo = User.PersonalInfoForVerified;
            uvm.Status = User.Status;
            uvm.LastLoginDate = User.LastLoginDate;
            uvm.ProjectCount = User.ProjectCount;
            uvm.RegistrationDate = User.RegistrationDate;
            return uvm;
        }


        public static User GetIdentityUser(this ICollection<User> _context, string Email)
        {
            User user = _context.GetUserByEmail(Email);
            return user;
        }

        public static List<UserViewModel> GetListUVM(this ICollection<User> _context)
        {
            List<UserViewModel> UsersVM = new List<UserViewModel>();
            List<User> Users = _context.ToList();
            for (int i = 0; i < Users.Count; i++)
            {
                UserViewModel uvm = Users[i].UserToVM();
                UsersVM.Add(uvm);
            }
            return UsersVM;
        }
    }
}