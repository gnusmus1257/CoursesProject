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
