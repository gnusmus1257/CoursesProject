using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models
{
    public class Project
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int FinancialTarget { get; set; }
        public int DonateCount { get; set; }
        public int PaymentCount { get; set; }
        public EStatus Status { get; set; }
        public ECategory Category { get; set; }
        
        public enum EStatus { Succses, Fail, Active }
        public enum ECategory { Bussines, Games, Education, Art }
    }
    public class Comments
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }

    public class Ratings
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public int Rating { get; set; }
    }

    public class Tags
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Tag { get; set; }
    }
}
