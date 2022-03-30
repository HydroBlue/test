using Microsoft.EntityFrameworkCore;
using MyApp_220329.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp_220329.Data
{
    public class MyAppContext : DbContext
    {
        // 생성자 - 매개변수 options를 DbContext의 생성자(base)로 넘겨 base 클래스에서 DB연결 담당 및 기타 환경 설정을 하도록 함
        public MyAppContext( DbContextOptions options ) : base( options ) {}

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set;  }

        internal Task SaveChangeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
