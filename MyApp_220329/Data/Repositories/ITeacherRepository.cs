using System.Collections.Generic;
using MyApp_220329.Models;

namespace MyApp_220329.Data.Repositories
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacher(int id);
    }
}