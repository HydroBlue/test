using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp_220329.Data.Repositories;
using MyApp_220329.Models;
using MyApp_220329.VIewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp_220329.Controllers
{
    // Controller를 상속받음
    public class HomeController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;

        public HomeController( ITeacherRepository teacherRepository, IStudentRepository studentRepository )
        {
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }


        public IActionResult Index()
        {
            /*
            // List teachers에 Teacher 데이터 입력
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() { Name = "세종대왕", Class = "한글" },
                new Teacher() { Name = "이순신", Class = "해상전략" },
                new Teacher() { Name = "제갈량", Class = "지략" },
                new Teacher() { Name = "을지문덕", Class = "지상전략" }
            };
            */

            // Teachers 테이블의 데이터 불러오기
            var teachers = _teacherRepository.GetAllTeachers();

            // StudentTeacherViewModel 인스턴스화
            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View( viewModel );
        }



        // GET: /<controller>/
        // Razor파일(VIews)을 디스플레이하는 역할
        public IActionResult Student()
        {
            // List teachers에 Teacher 데이터 입력
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() { Name = "세종대왕", Class = "한글" },
                new Teacher() { Name = "이순신", Class = "해상전략" },
                new Teacher() { Name = "제갈량", Class = "지략" },
                new Teacher() { Name = "을지문덕", Class = "지상전략" }
            };

            // StudentTeacherViewModel 인스턴스화
            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            // 함수 내 코드를 알맞게 VIew에 담아 return
            return View( viewModel );
        }


        // [HttpPost] : HTML View에서 넘어온 값을 받는 역할
        //[HttpPost]
        //public IActionResult Student( [Bind("Name, Age")] Student model ) // BInd : 특정 데이터만 받아옴
        [HttpPost]
        [ValidateAntiForgeryToken] // 유저가 서버로 Form 입력값을 보낼 때 유저에게 제공된 Form이 맞는지 토큰을 비교하여 다르면 차단
        public IActionResult Student( StudentTeacherViewModel model ) //  일반적인 형태, 혹은 Model에서 Bind 했을 경우
        {
            // 유효성 검사(제약조건 만족여부 확인) - true, false return
            if( ModelState.IsValid )
            {
                // true - model 데이터를 Student 테이블에 저장

                // _studentRepository.AddStudent 함수 호출
                // view에서 form을 통해 넘어온 데이터를 Student 테이블에 입력할 준비
                _studentRepository.AddStudent( model.Student );

                // _studentRepository.Save 함수 호출
                // 실제 DB에 데이터 입력
                _studentRepository.Save();
            }
            else
            {
                // false - 에러 출력
            }

            return View();
        }
    }
}
