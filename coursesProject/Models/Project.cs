using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models
{
    public class Project
    {
        public int ID { get; set; }
        public User Athor { get; set; }
        public string NameProject { get; set; }
        public DateTime Date { get; set; }
        public EStatus Status { get; set; }
        public ECategory Category { get; set; }
        public Comments Comment { get; set; }
        public Ratings Raiting { get; set; }
        public Goals Goals { get; set; }       
    }


    public enum EStatus { Succses, Fail, Active }
    public enum ECategory { Bussines, Games, Education, Art }


    public class Comments
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }


    public class Ratings
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public int Rating { get; set; }
    }


    public class Tags
    {
        public int ID { get; set; }
        public string Tag { get; set; }
    }


    public class TagRelation
    {
        public int ID { get; set; }
        public Project Project { get; set; }
        public Tags Tag { get; set; }
    }


    public class Goals
    {
        public int ID { get; set; }
        public int NeedMoney { get; set; }
        public Project Project { get; set; }
        public string Goal { get; set; }
    }


    public class News
    {
        public int ID { get; set; }
        public Project Project { get; set; }
        public string Text { get; set; }
    }


    public class Subscribers
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
    }
}
