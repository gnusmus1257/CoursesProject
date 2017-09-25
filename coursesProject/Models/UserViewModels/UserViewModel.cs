using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models
{
    public class UserViewModel
    {////////////////////                   МОДЕЛЬ ДЛЯ ПОЛЬЗОВАТЕЛЯ (ПОКА ВЫВОД КАРТИНКИ СКАНА ПАСПОРТА И АВАТАРКИ)
        public int ID { get; set; }
        public int User { get; set; }
        public string Email { get; set; }
        public IFormFile Avatar { get; set; }
        public byte[] AvatarByte { get; set; }
        public IFormFile PasportScan { get; set; }
        public byte[] PasportScanByte { get; set; }
        public string PersonalInfo { get; set; }
        public string Comment { get; set; }
        public bool IsBanned { get; set; }
        public string Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int Rating { get; set; }
        public int ProjectCount { get; set; }
    }
}
