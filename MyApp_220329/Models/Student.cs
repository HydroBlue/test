using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp_220329.Models
{
    public class Student
    {
        // 변수 선언 및 getter, setter 생성

        // 엔티티 프레임워크 코어 사용을 위해 Id 선언
        public int Id { get; set; }

        //[BindNever] // 해당 변수명에 해당하는 데이터는 불러오지 않음
        [Required] // 필수값 설정 - not null
        [MaxLength(50)] // 최대 글자수 제한
        public String Name { get; set; }

        [Range(15, 70)] // 숫자 범위 제한
        public int Age { get; set; }

        [Required] // 필수값 설정 - not null
        [MinLength(5)] // 필수값 설정, 최소 글자수 제한 - 함께 쓸 수도 있음
        public String Country { get; set; }
    }
}
