using MyApp_220329.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp_220329.Data
{
    public class DbSeeder
    {
        private MyAppContext _context;

        public DbSeeder( MyAppContext context )
        {
            _context = context;
        }


        // async : 비동기 프로그래밍 키워드로, 사용 시 Task 타입을 함께 작성
        public async Task SeedDatabase()
        {
            if( !_context.Teachers.Any() )
            {
                // Teachers 테이블 내에 데이터가 없을 경우 실행
                // List teachers에 Teacher 데이터 입력
                List<Teacher> teachers = new List<Teacher>()
                {
                    new Teacher() { Name = "세종대왕", Class = "한글" },
                    new Teacher() { Name = "이순신", Class = "해상전략" },
                    new Teacher() { Name = "제갈량", Class = "지략" },
                    new Teacher() { Name = "을지문덕", Class = "지상전략" }
                };

                // Teachers 테이블에 List teachers에 입력된 데이터를 입력 준비
                // AddRangeAsync( list ) : 리스트 형태 데이터 입력
                await _context.AddRangeAsync( teachers );

                // AddASync( 데이터 ) : 단일 데이터 입력
                //await _context.AddRangeAsync( new Teacher() { Name = "세종대왕", Class = "한글" } );

                // 데이터를 테이블에 저장
                await _context.SaveChangesAsync();
            }
        }
    }
}
