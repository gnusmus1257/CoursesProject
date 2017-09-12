using coursesProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Service
{
    public static class ImgToByte
    {
        public static byte[] GetImg(this UserViewModel uvm)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов
            using (var binaryReader = new BinaryReader(uvm.Avatar.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)uvm.Avatar.Length);
            }
            return imageData;
        }
    }
}
