using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models.ProjectViewModels
{
    public class MinProjectViewModel
    {
        public string NameProject { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int CollectMoney { get; set; }
        public string MinDescription { get; set; }
        public byte[] AvatarByte { get; set; }
        public IFormFile Avatar { get; set; }
        public string Category { get; set; }
        public double Raiting { get; set; }
    }
}
