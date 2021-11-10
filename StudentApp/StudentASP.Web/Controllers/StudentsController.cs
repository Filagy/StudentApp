using Microsoft.AspNetCore.Mvc;
using StudentASP.Domain.Interfaces;
using StudentASP.Web.ViewModels;

namespace StudentASP.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsRepository _allStudents;
        private readonly IStudentsRepository _badStudents;

        public StudentsController(IStudentsRepository allStudents)
        {
            _allStudents = allStudents;
        }

        public ViewResult GetAllStudents()
        {

            return View();
        }
        public ViewResult BadStudents()
        {


            return View();
        }
    }
}
