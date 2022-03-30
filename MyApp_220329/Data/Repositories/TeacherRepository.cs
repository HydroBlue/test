using MyApp_220329.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp_220329.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyAppContext _context;

        public TeacherRepository( MyAppContext context )
        {
            _context = context;
        }


        // Teachers 리스트를 불러오는 함수
        // IEnumerable : 데이터를 읽어올 때 List보다 더 효율적
        public IEnumerable<Teacher> GetAllTeachers()
        {
            // 데이터를 List 형태로 변환하여 변수에 저장
            var result = _context.Teachers.ToList();

            return result;
        }


        // id를 매개변수로 하여 Teachers 테이블에 해당 id값과 일치하는 데이터를 불러오는 함수
        public Teacher GetTeacher( int id )
        {
            // 매개변수의 id값을 통하여 검색하여 검색된 데이터를 변수에 저장
            var result = _context.Teachers.Find( id );

            return result;
        }
    }
}
