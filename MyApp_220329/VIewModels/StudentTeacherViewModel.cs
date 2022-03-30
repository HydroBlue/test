using MyApp_220329.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp_220329.VIewModels
{
    public class StudentTeacherViewModel
    {
        public Student Student { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
