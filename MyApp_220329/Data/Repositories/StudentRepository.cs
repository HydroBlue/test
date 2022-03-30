using MyApp_220329.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp_220329.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyAppContext _context;

        public StudentRepository( MyAppContext context )
        {
            _context = context;
        }


        // Student 테이블에 데이터 입력
        public void AddStudent( Student student )
        {
            // Students DB에 student를 Add하는 변동사항을 추적 - 실제로 Add하는 것은 아님
            _context.Students.Add( student );
        }

        public void Save()
        {
            // AddStudent 함수에서 Add한 데이터를 실제로 DB에 입력
            _context.SaveChanges();
        }
        //


        // DB에서 데이터 불러오기
        public IEnumerable<Student> GetAllStudents()
        {
            // 데이터를 List 형태로 변환하여 변수에 저장
            var result = _context.Students.ToList();

            return result;
        }


        // id를 매개변수로 하여 Student 테이블에 해당 id값과 일치하는 데이터를 불러오는 함수
        public Student GetStudent( int id )
        {
            // 매개변수의 id값을 통하여 검색하여 검색된 데이터를 변수에 저장
            var result = _context.Students.Find( id );

            return result;
        }
    }
}
