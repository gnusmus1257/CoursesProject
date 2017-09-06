using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public int SelfProjects { get; set; }
        public int SubProjects { get; set; }

        public int CommentsCount { get; set; }
        public int PaymentCount { get; set; }
        public int GeneralDonate { get; set; }
        public int SuccesProjectsCount { get; set; }
        public ERole Role { get; set; }
        public ELanguage Language { get; set; }

        public enum ERole { User, ChekedUser, Admin}
        public enum ELanguage { Ru, En}


    }
}
