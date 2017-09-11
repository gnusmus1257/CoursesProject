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
        public IFormFile Avatar { get; set; }
        public IFormFile PasportScan { get; set; }
    }
}
