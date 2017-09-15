using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models.ProjectViewModels
{
    public class CreateProjectViewModel
    {
        public string nameProject { get; set; }
        public string Descrtiption { get; set; }
        public string ShortDescription { get; set; }
        public DateTime EndTime { get; set; }
        public IFormFile Avatar { get; set; }
        public string Category { get; set; }
        public int NeedMoney { get; set; }
        public string Goal { get; set; }
    }
}
