using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models
{
    public class User
    {
        public int ID { get; set; }
        public ApplicationUser IdentityUser { get; set; }
        public MedalRelation Medal { get; set; }                        
        public ELanguage Language { get; set; }       
        public Statistics Stats { get; set; }
    }


    
    public enum ELanguage { Ru, En }


    public class Medals
    {
        public int ID { get; set; }
        public string Medal { get; set; }
    }

    public class MedalRelation
    {
        public int ID { get; set; }
        public Medals Medal { get; set; }
        public User User { get; set; }
    }


    public class Statistics
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int DonateCount { get; set; }
        public int MoneyDonate { get; set; }
        public int SuccesProject { get; set; }
    }
}
