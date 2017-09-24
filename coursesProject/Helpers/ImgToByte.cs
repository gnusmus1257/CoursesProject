using coursesProject.Models;
using coursesProject.Models.ProjectViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Service
{
    public static class ImgToByte
    {
        public static byte[] GetImg( this IFormFile img)
        {
            byte[] imageData = null;
            var binaryReader = new BinaryReader(img.OpenReadStream());
            imageData = binaryReader.ReadBytes((int)img.Length);
            return imageData;
        }
        public static byte[] GetImg(this CreateProjectViewModel uvm)
        {
            byte[] imageData = null;
            if (uvm.Avatar!=null)
            {
                using (var binaryReader = new BinaryReader(uvm.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)uvm.Avatar.Length);
                }
            }
            return imageData;
        }

    }
}
