using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models.ProjectViewModels
{
    public class EditProjectViewModel
    {
        public int ID { get; set; }
        public string NameProject { get; set; }
        public DateTime EndDate { get; set; }
        public int NeedMoney { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
