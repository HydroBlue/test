using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp_220329.Models
{
    public class Teacher
    {
        // 엔티티 프레임워크 코어 사용을 위해 Id 선언
        public int Id { get; set; }

        public String Name { get; set; }

        public String Class { get; set; }
    }
}
