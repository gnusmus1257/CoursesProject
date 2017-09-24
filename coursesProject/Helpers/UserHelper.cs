using coursesProject.Data;
using coursesProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Helpers
{
    public static class UserHelper
    {
        public  static User GetUserById(this ApplicationDbContext _context, int idUser)
        {
            User user =  _context.User.FirstOrDefault(x => x.ID == idUser);
            return user;
        }

        public static User GetUserByEmail(this ApplicationDbContext _context, string Email)
        {
            User user = _context.User.FirstOrDefault(x => x.Email == Email);
            return user;
        }

        public static List<User> GetUserListByListID(this ApplicationDbContext _context, List<int> idUsers)
        {
            List<User> users = new List<User>();
            foreach (var item in idUsers)
            {
                users.Add( _context.User.First(x => x.ID == item));
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
            return uvm;
        }


        public static User GetIdentityUser(this ApplicationDbContext _context,string Email)
        {
            User user = _context.GetUserByEmail(Email);
            return user;
        }
        public static List<UserViewModel> GetListUVM( this ApplicationDbContext _context)
        {
            List<UserViewModel> UsersVM = new List<UserViewModel>();
            List<User> Users = _context.User.ToList();
            for (int i = 0; i < _context.User.ToList().Count; i++)
            {
                UserViewModel uvm = Users[i].UserToVM();
                UsersVM.Add(uvm);
            }
            return UsersVM;
        }
    }
}
