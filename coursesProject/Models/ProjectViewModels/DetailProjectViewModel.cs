using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models.ProjectViewModels
{
    public class DetailProjectViewModel
    {
        public int ID { get; set; }
        public User Athor { get; set; }
        public string AthorEmail { get; set; }
        public string NameProject { get; set; }
        public DateTime DateOfRigister { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int CollectMoney { get; set; }
        public int NeedMoney { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public byte[] Avatar { get; set; }
        public string Category { get; set; }
        public string Goal { get; set; }
        public string Comment { get; set; }
        public string Tag { get; set; }
        public string TagStr { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public double Raiting { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<Subscriber> Subscriber { get; set; }
        public ICollection<New> News { get; set; }
        public bool IsAthor { get; set; }

        public DetailProjectViewModel()
        {
            Comments = new List<Comment>();
            Goals = new List<Goal>();
            Subscriber = new List<Subscriber>();
            News = new List<New>();
        }
    }
}
