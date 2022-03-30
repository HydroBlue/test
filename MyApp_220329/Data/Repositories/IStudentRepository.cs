using System.Collections.Generic;
using MyApp_220329.Models;

namespace MyApp_220329.Data.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        void Save();
    }
}