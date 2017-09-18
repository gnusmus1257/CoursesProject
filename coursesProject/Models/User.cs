using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace coursesProject.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public ApplicationUser IdentityUser { get; set; }
        public ICollection<MedalRelation> Medal { get; set; }
        public string Region { get; set; }
        public ICollection<Statistic> Stats { get; set; }
        public string Status { get; set; } // ПРОВЕРЕН (verified), ЖДЕТ ПРОВЕРКИ(applied), НЕ ПРОВЕРЕН
        public bool IsBan { get; set; }
        public byte[] Avatar { get; set; }
        public byte[] PasportScan { get; set; }
        public string PersonalInfoForVerified { get; set; }
        public string CommentForVerified { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int Rating { get; set; }
        public int ProjectCount { get; set; }
    }


    public class Medal
    {
        public int ID { get; set; }
        public string Text { get; set; }
    }

    public class MedalRelation
    {
        public int ID { get; set; }
        public Medal Medal { get; set; }
        [Required]
        public ICollection<User> User { get; set; }
    }

    public class Statistic
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        [Required]
        public User User { get; set; }
        public int DonateCount { get; set; }
        public int MoneyDonate { get; set; }
        public int SuccesProject { get; set; }
    }
}
